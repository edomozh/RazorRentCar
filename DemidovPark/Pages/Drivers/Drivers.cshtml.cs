namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    
    
    public class DriversModel : PageModel
    {
        readonly AppDbContext context;

        public List<Driver> Drivers { get; private set; } = new();

        public DriversModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGet()
        {
            Drivers = await context.Drivers.ToListAsync();
            Drivers = Drivers.OrderByDescending(d => d.Debt).ToList();
            return Page();
        }
    }
}