namespace RentApp.Pages
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using RentApp.Data;

    public class DriverNewModel : PageModel
    {
        AppDbContext context;

        [BindProperty]
        public Driver Driver { get; set; } = new();

        public DriverNewModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            context.Drivers.Add(Driver);
            await context.SaveChangesAsync();
            return RedirectToPage("/Drivers/Drivers");
        }
    }
}