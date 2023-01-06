namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using DemidovPark.Helpers;
    using DemidovPark.Hubs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using Serilog;

    public class IndexModel : PageModel
    {
        readonly AppDbContext context;
        readonly IHubContext<AskingHub> hub;
        readonly ILogger<IndexModel> logger;

        public List<Car> Cars { get; private set; } = new();

        [BindProperty]
        [DataType(DataType.DateTime)]
        public DateTime DateOne { get; set; } = DateTime.Today.AddHours(DateTime.Now.Hour);

        [BindProperty]
        [DataType(DataType.DateTime)]
        public DateTime DateTwo { get; set; } = DateTime.Today.AddDays(1).AddHours(12);

        public SelectList Distances { get; set; }

        [BindProperty]
        public ulong SegmentId { get; set; }
        public SelectList Segments { get; set; }

        [BindProperty]
        public Request NewRequest { get; set; } = new();

        public IndexModel(AppDbContext context, IHubContext<AskingHub> hub, ILogger<IndexModel> logger)
        {
            this.context = context;
            this.hub = hub;
            this.logger = logger;
            Distances = new SelectList(context.Distances, nameof(SegmentItem.Id), nameof(SegmentItem.Name));
            Segments = new SelectList(context.Segments, nameof(SegmentItem.Id), nameof(SegmentItem.Name));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var one = DateOne;
            var two = DateTwo;

            DateOne = one < two ? one : two;
            DateTwo = one > two ? one : two;

            Cars = await context.Cars.Include(c => c.Segment).Include(c => c.Contracts).ToListAsync();
            Cars = Cars
                .Where(c => c.Archive == false)
                .Where(c => !c.Contracts.Any(r => r.Start < DateTime.Now && r.Finished == false))
                .Where(c => !c.Contracts.Any(r => DateRange.IntersectionRanges(DateOne, DateTwo, r.Start, r.Finish) && !(!r.Finished && r.Endless))).ToList();

            if (SegmentId != 0)
            {
                Cars = Cars.Where(c => c.SegmentId == SegmentId).ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostSelectAsync()
        {
            return await OnGetAsync();
        }

        public async Task<IActionResult> OnPostNewRequestAsync()
        {
            try
            {

                NewRequest.CarId = (ulong)int.Parse(Request.Form["carId"].First());
                NewRequest.Start = DateTime.Parse(Request.Form["start"].First());
                NewRequest.Finish = DateTime.Parse(Request.Form["finish"].First());

                context.Requests.Add(NewRequest!);
                await context.SaveChangesAsync();

                ModelState.AddModelError("", "Заявка создана.");

                var car = await context.Cars.FirstAsync(c => c.Id == NewRequest.CarId);
                await hub.Clients.All.SendAsync("NewAskReceived", $"Новая заявка на {car.Name}");

                return Page();
            }
            catch { return NotFound(); }
        }
    }
}