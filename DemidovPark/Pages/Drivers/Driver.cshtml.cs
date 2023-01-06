namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DriverModel : PageModel
    {
        readonly AppDbContext context;

        [BindProperty]
        public Driver Driver { get; set; } = new();

        public DriverModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGet(ulong id)
        {
            Driver = await context.Drivers.AsNoTracking().FirstAsync(d => d.Id == id);

            Driver.Contracts = await context.Contracts.AsNoTracking()
                .Include(r => r.Driver)
                .Include(r => r.Car)
                .Where(r => r.DriverId == Driver.Id)
                .Where(r => r.Start > DateTime.Now.AddYears(-1))
                .OrderBy(r => r.Start)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteDriverAsync(ulong id)
        {
            Driver = await context.Drivers.FirstAsync(d => d.Id == id);

            context.Drivers.Remove(Driver);
            await context.SaveChangesAsync();

            return RedirectToPage("/Drivers/Drivers");
        }
    }
}