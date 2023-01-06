namespace DemidovPark.Pages.Cars
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class MaintenanceModel : PageModel
    {
        AppDbContext context;

        [BindProperty]
        public Car Car { get; set; } = new();

        [BindProperty]
        public Maintenance NewService { get; set; } = new();

        [BindProperty]
        public MainHistory NewHistory { get; set; } = new();

        [BindProperty]
        public Mileage NewMileage { get; set; } = new();

        public SelectList Services { get; set; }

        public MaintenanceModel(AppDbContext db)
        {
            context = db;
            Services = new SelectList(Car.Maintenances, nameof(Maintenance.Id), nameof(Maintenance.Name)); 
        }

        public async Task<IActionResult> OnGetAsync(ulong id)
        {
            await LoadViewData(id);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteServiceAsync(ulong id)
        {
            var service = await context.Maintenances.FindAsync(id);

            if (service is null) return NotFound();

            context.Maintenances.Remove(service);
            await context.SaveChangesAsync();

            await LoadViewData(Car.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteMilleageAsync(ulong id)
        {
            var milleage = await context.Mileages.FindAsync(id);

            if (milleage is null) return NotFound();

            context.Mileages.Remove(milleage);
            await context.SaveChangesAsync();

            await LoadViewData(Car.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteHistoryAsync(ulong id)
        {
            var hist = await context.MainHistories.FindAsync(id);

            if (hist is null) return NotFound();

            context.MainHistories.Remove(hist);
            await context.SaveChangesAsync();

            await LoadViewData(Car.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAddServiceAsync(ulong id)
        {
            NewService.CarId = Car.Id;
            context.Maintenances.Add(NewService!);
            await context.SaveChangesAsync();

            await LoadViewData(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAddMileageAsync(ulong id)
        {
            NewMileage.CarId = Car.Id;
            context.Mileages.Add(NewMileage!);
            await context.SaveChangesAsync();

            await LoadViewData(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAddHistoryAsync(ulong id)
        {
            context.MainHistories.Add(NewHistory!);
            await context.SaveChangesAsync();

            await LoadViewData(id);

            return Page();
        }

        public async Task LoadViewData(ulong id)
        {
            Car = await context.Cars.AsNoTracking().FirstAsync(c => c.Id == id);

            Car.Maintenances = await context.Maintenances.AsNoTracking()
                 .Include(s => s.Car)
                 .Where(s => s.CarId == Car.Id)
                 .ToListAsync();

            Car.Mileages = await context.Mileages.AsNoTracking()
                 .Include(m => m.Car)
                 .Where(m => m.CarId == Car.Id)
                 .ToListAsync();

            Car.History = await context.MainHistories.AsNoTracking()
                .Include(h => h.Maintenance)
                .Where(h => Car.Maintenances.Select(s => s.Id).Contains(h.MaintenanceId))
                .ToListAsync();

            Services = new SelectList(Car.Maintenances, nameof(Maintenance.Id), nameof(Maintenance.Name));
        }

    }
}