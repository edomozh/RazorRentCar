namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using DemidovPark.Views;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class CarEdit : PageModel
    {
        readonly AppDbContext context;
        readonly IWebHostEnvironment env;

        [BindProperty]
        public Car Car { get; set; } = new();

        [BindProperty]
        public PhotoView Photo { get; set; } = new();

        public SelectList Segments { get; set; }

        public CarEdit(AppDbContext db, IWebHostEnvironment whe)
        {
            context = db;
            env = whe;
            Segments = new SelectList(db.Segments, nameof(SegmentItem.Id), nameof(SegmentItem.Name));
        }

        public async Task<IActionResult> OnGetAsync(ulong id)
        {
            Car = await context.Cars.FirstAsync(c => c.Id == id);

            if (Car is null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            using var stream = new MemoryStream();

            if (Photo.FormFile?.Length > 0)
            {
                await Photo.FormFile.CopyToAsync(stream);

                if (Car.PhotoId == 0 || Car.PhotoId == null)
                {
                    var photo = new Photo
                    {
                        Value = stream.ToArray()
                    };
                    context.Photos.Add(photo);
                    await context.SaveChangesAsync();
                    Car.PhotoId = photo.Id;
                }
                else
                {
                    var photo = await context.Photos.FirstAsync(c => c.Id == Car.PhotoId);
                    photo.Value = stream.ToArray();
                    context.Photos.Update(photo);
                    await context.SaveChangesAsync();
                }
            }

            context.Cars.Update(Car!);
            await context.SaveChangesAsync();
            return RedirectToPage("/Cars/Car", new { Car.Id });
        }
    }
}