namespace RentApp.Pages
{
    using RentApp.Data;
    using RentApp.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    public class ReportModel : PageModel
    {
        readonly AppDbContext context;

        [BindProperty]
        [DataType("month")]
        public DateTime Month { get; set; } = DateTime.Today;

        public ReportModel(AppDbContext db)
        {
            context = db;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var payments = await context
                .Payments.Where(p => p.Date.Year == Month.Year && p.Date.Month == Month.Month).ToListAsync();

            var expenses = await context
               .Expenses.Where(p => p.Date.Year == Month.Year && p.Date.Month == Month.Month).ToListAsync();

            ViewData["Paid"] = payments.Sum(p => p.Paid!.Calc());
            ViewData["Income"] = payments.Sum(p => p.Income);
            ViewData["MyIncome"] = payments.Sum(p => p.MyIncome);
            ViewData["Debt"] = payments.Sum(p => p.Debt);
            ViewData["Expense"] = expenses.Sum(p => p.Value);

            var drivers = await context.Drivers.Where(d => d.Debt != 0).ToListAsync();
            ViewData["DriversDebt"] = drivers.Sum(d => d.Debt);

            return Page();
        }
    }
}