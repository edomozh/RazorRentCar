namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;

    
    
    public class CarNewModel : PageModel
    {
        AppDbContext context;

        [BindProperty]
        public Car Car { get; set; } = null!;

        public SelectList Segments { get; set; }

        public CarNewModel(AppDbContext db)
        {
            context = db;
            Segments = new SelectList(db.Segments, nameof(SegmentItem.Id), nameof(SegmentItem.Name));
            Car = new();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            context.Cars.Add(Car!);
            await context.SaveChangesAsync();
            return RedirectToPage("/Cars/Cars");
        }
    }
}