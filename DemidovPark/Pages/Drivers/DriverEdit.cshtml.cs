namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;

    public class DriverEditModel : PageModel
    {
        AppDbContext context;

        [BindProperty]
        public Driver Driver { get; set; } = null!;

        public DriverEditModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGetAsync(ulong id)
        {
            Driver = await context.Drivers.FirstAsync(d => d.Id == id);

            if (Driver is null) return NotFound();

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(ulong id)
        {
            if (Driver is null) return NotFound();
            context.Drivers.Update(Driver);
            await context.SaveChangesAsync();
            return RedirectToPage("/Drivers/Driver", new { Driver.Id });
        }
    }
}