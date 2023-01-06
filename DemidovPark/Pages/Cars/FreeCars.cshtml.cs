namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using DemidovPark.Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Authorize]
    public class FreeCarsModel : PageModel
    {
        readonly AppDbContext context;

        public List<Car> Cars { get; private set; } = new();

        [BindProperty]
        [DataType(DataType.DateTime)]
        public DateTime DateOne { get; set; } = DateTime.Today.AddHours(DateTime.Now.Hour);

        [BindProperty]
        [DataType(DataType.DateTime)]
        public DateTime DateTwo { get; set; } = DateTime.Today.AddDays(1).AddHours(12);

        public FreeCarsModel(AppDbContext db)
        {
            context = db;
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
                .Where(c => !c.Contracts.Any(r => r.Endless && !r.Finished))
                .Where(c => !c.Contracts.Any(r => DateRange.IntersectionRanges(DateOne, DateTwo, r.Start, r.Finish))).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return await OnGetAsync();
        }
    }
}