namespace DemidovPark.Services
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("[controller]")]
    [ApiController]
    public class Indicators : ControllerBase
    {
        readonly AppDbContext context;

        public Indicators(AppDbContext db)
        {
            context = db;
        }

        [Route("OverdueContracts")]
        [HttpGet]
        public string OverdueContracts()
        {
            var Contracts = context.Contracts
                .AsNoTracking()
                .Include(c => c.Car)
                .Include(c => c.Driver)
                .Include(r => r.Payments)
                .ToList();

            var count = Contracts.Where(c => c.Status == "danger").Count();
            return count > 0 ? count.ToString() : "";
        }

        [Route("OverdueCars")]
        [HttpGet]
        public string OverdueCars()
        {
            var Cars = context.Cars
                 .AsNoTracking()
                 .Include(c => c.Maintenances)
                 .Include(c => c.Segment)
                 .Include(c => c.Mileages)
                 .Where(c => c.Archive == false)
                 .ToList();

            var counter = 0;

            foreach (var car in Cars)
            {
                var latestMilleage = car.Mileages.OrderByDescending(m => m.Date).FirstOrDefault();
                if (latestMilleage is null)
                {
                    counter++;
                    continue;
                }

                var dayToMilleageCheckup = 5 - (DateTime.Now.Date - latestMilleage.Date).Days;
                if (dayToMilleageCheckup <= 0)
                {
                    counter++;
                    continue;
                }

                var history = context.MainHistories
                    .AsNoTracking()
                    .Include(h => h.Maintenance)
                    .Where(c => c.Maintenance!.CarId == car.Id)
                    .ToList();

                foreach (var maintenance in car.Maintenances)
                {
                    var latestHist = history.OrderByDescending(c => c.Date).Where(h => h.MaintenanceId == maintenance.Id).FirstOrDefault();
                    if ((latestHist is null ? 0 : latestHist.Next) - latestMilleage.Value <= 0)
                    {
                        counter++;
                        break;
                    }
                }
            }


            return counter > 0 ? counter.ToString() : "";
        }

        [Route("OverdueRequests")]
        [HttpGet]
        public string OverdueRequests()
        {
            var requests = context.Requests.AsNoTracking().ToList();
            var count = requests.Where(c => c.Processed != true).Count();
            return count > 0 ? count.ToString() : "";
        }

    }
}
