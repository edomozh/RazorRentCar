namespace RentApp.Pages
{
    using RentApp.Data;
    using RentApp.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using RentApp.Data;

    public class ContractEditModel : PageModel
    {
        AppDbContext context;

        [BindProperty]
        public Contract Contract { get; set; } = new();

        public SelectList Drivers { get; set; }

        public string Intersect { get; set; } = string.Empty;

        public ContractEditModel(AppDbContext db)
        {
            context = db;
            Drivers = new SelectList(db.Drivers.OrderBy(c => c.FirstName), nameof(Driver.Id), nameof(Driver.FullName));
        }

        public async Task LoadContract(ulong id)
        {
            Contract = await context.Contracts.AsNoTracking().Include(r => r.Driver).Include(r => r.Car).Include(r => r.Payments).FirstAsync(r => r.Id == id);
        }

        public async Task<IActionResult> OnGetAsync(ulong id)
        {
            await LoadContract(id);
            if (Contract is null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Contract is null) return NotFound();

            var intersectTental = context.Contracts.AsNoTracking().Include(r => r.Car).Include(r => r.Driver)
                 .Where(r => r.Id != Contract.Id && r.CarId == Contract.CarId).ToList()
                 .FirstOrDefault(r => DateRange.IntersectionRanges(Contract.Start, Contract.Finish, r.Start, r.Finish) || (!r.Finished && r.Endless));

            if (intersectTental is not null)
            {
                var msg = $"Обнаружено пересечение с арендой {intersectTental.ViewName} {intersectTental.Start}";
                ModelState.AddModelError(string.Empty, msg);
                Contract.Car = await context.Cars.FindAsync(Contract.CarId);
                return Page();
            }

            context.Contracts.Update(Contract!);
            await context.SaveChangesAsync();
            return RedirectToPage("/Contracts/Contract", new { Contract.Id });
        }
    }
}