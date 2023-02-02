namespace RentApp.Pages
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using RentApp.Data;
    using System.Threading.Tasks;

    public class RequestsModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Request> Requests { get; set; } = new();

        public RequestsModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Requests != null)
            {
                Requests = await _context.Requests
                    .AsNoTracking()
                    .Include(r => r.Car)
                    .Include(r => r.Distance)
                    .OrderByDescending(r => r.CreatedDate)
                    .OrderBy(r => r.Processed)
                    .Take(20)
                    .ToListAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostProceedAsync(ulong id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null) return NotFound();
            request.Processed = true;
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Requests");
        }
    }
}
