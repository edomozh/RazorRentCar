namespace RentApp.Pages.Cars
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using RentApp.Data;

    public class AllCarsModel : PageModel
    {
        readonly AppDbContext context;

        public List<Car> Cars { get; private set; } = new();
        public Dictionary<ulong, string> Mileages { get; private set; } = new();
        public Dictionary<ulong, string> NextMilleageCheckups { get; private set; } = new();
        public Dictionary<ulong, string> NextMaintenanceСheckup { get; private set; } = new();
        public Dictionary<ulong, string> Colors { get; private set; } = new();

        public AllCarsModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Cars = await context.Cars
                .AsNoTracking()
                .Include(c => c.Maintenances)
                .Include(c => c.Segment)
                .Include(c => c.Mileages)
                .Where(c => c.Archive == false).ToListAsync();

            Mileages = Cars.ToDictionary(c => c.Id, c => string.Empty);
            NextMilleageCheckups = Cars.ToDictionary(c => c.Id, c => string.Empty);
            NextMaintenanceСheckup = Cars.ToDictionary(c => c.Id, c => string.Empty);
            Colors = Cars.ToDictionary(c => c.Id, c => "white");

            foreach (var car in Cars)
            {
                var latestMilleage = car.Mileages.OrderByDescending(m => m.Date).FirstOrDefault();
                if (latestMilleage is null)
                {
                    Colors[car.Id] = "danger";
                    Mileages[car.Id] = "пробег не найден";
                    continue;
                }
                Mileages[car.Id] = latestMilleage.Value.ToString();

                var dayToMilleageCheckup = 5 - (DateTime.Now.Date - latestMilleage.Date).Days;
                NextMilleageCheckups[car.Id] = dayToMilleageCheckup.ToString();
                if (dayToMilleageCheckup <= 0) Colors[car.Id] = "danger";

                var history = await context.MainHistories
                    .AsNoTracking()
                    .Include(h => h.Maintenance)
                    .Where(c => c.Maintenance.CarId == car.Id)
                    .ToListAsync();

                var nextMaintenances = new List<string>();
                foreach (var maintenance in car.Maintenances)
                {
                    var latestHist = history.OrderByDescending(c => c.Date).Where(h => h.MaintenanceId == maintenance.Id).FirstOrDefault();
                    nextMaintenances.Add(latestHist is null ? $"{maintenance.Name} {0}" : $"{maintenance.Name} {(int)latestHist.Next - (int)latestMilleage.Value}");

                    if ((latestHist is null ? 0 : latestHist.Next) - (latestMilleage.Value + 500) <= 0)
                        Colors[car.Id] = "danger";

                    if ((latestHist is null ? 0 : latestHist.Next) - (latestMilleage.Value + 1000) <= 0)
                        Colors[car.Id] = "warning";
                }

                NextMaintenanceСheckup[car.Id] = String.Join("; ", nextMaintenances);
            }

            Cars = Cars.OrderBy(c => Colors[c.Id]).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return await OnGetAsync();
        }
    }
}