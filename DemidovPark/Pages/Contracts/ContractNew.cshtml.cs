namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using DemidovPark.Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    
    
    public class ContractNewModel : PageModel
    {
        AppDbContext context;

        [BindProperty]
        public Contract Contract { get; set; } = new();

        [BindProperty]
        public Driver Driver { get; set; } = new();

        public SelectList Drivers { get; set; }

        public ContractNewModel(AppDbContext db)
        {
            context = db;
            Drivers = new SelectList(db.Drivers.OrderBy(c => c.FirstName), nameof(Driver.Id), nameof(Driver.FullName));
        }

        public async Task<IActionResult> OnGetAsync(ulong carid, string start, string finish)
        {
            Contract.CarId = carid;

            if (!string.IsNullOrEmpty(start))
                Contract.Start = DateTime.Parse(start);

            if (!string.IsNullOrEmpty(finish))
                Contract.Finish = DateTime.Parse(finish);

            Contract.Car = await context.Cars.FindAsync(carid);

            return Page();
        }

        public async Task<IActionResult> OnPostRentAsync()
        {
            if (Contract is null) return NotFound();

            var intersectTental = context.Contracts.Include(r => r.Car).Include(r => r.Driver)
                .Where(r => r.CarId == Contract.CarId).ToList()
                .FirstOrDefault(r => DateRange.IntersectionRanges(Contract.Start, Contract.Finish, r.Start, r.Finish) || (!r.Finished && r.Endless));

            if (intersectTental is not null)
            {
                var msg = $"Обнаружено пересечение с арендой {intersectTental.ViewName} {intersectTental.Start}";
                ModelState.AddModelError(string.Empty, msg);

                Contract.Car = await context.Cars.FindAsync(Contract.CarId);
                return Page();
            }

            context.Contracts.Add(Contract!);
            await context.SaveChangesAsync();
            return RedirectToPage("/Contracts/Contract", new { Id = Contract.Id });
        }

        public async Task<IActionResult> OnPostNewDriverAsync(string start, string finish)
        {
            if (Driver is null) return NotFound();

            if (!string.IsNullOrEmpty(start))
                Contract.Start = DateTime.Parse(start);

            if (!string.IsNullOrEmpty(finish))
                Contract.Finish = DateTime.Parse(finish);

            context.Drivers.Add(Driver!);
            await context.SaveChangesAsync();

            Contract.Driver = Driver;
            Contract.DriverId = Driver.Id;

            Contract.Car = await context.Cars.FindAsync(Contract.CarId);

            return Page();
        }
    }
}