namespace RentApp.Pages
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using RentApp.Data;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    public class ExpensesModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Expense> Expenses { get; set; } = new();

        [BindProperty]
        [DataType("month")]
        public DateTime Month { get; set; } = DateTime.Today;

        public ExpensesModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            if (_context.Requests != null)
            {
                Expenses = await _context.Expenses
                    .AsNoTracking()
                    .Include(r => r.Car)
                    .Where(e => e.Date.Month == Month.Month && e.Date.Year == Month.Year)
                    .OrderByDescending(r => r.CreatedDate)
                    .ToListAsync();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveAsync(ulong id)
        {
            var request = await _context.Expenses.FindAsync(id);
            if (request == null) return NotFound();

            _context.Expenses.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Expenses");
        }
    }
}
