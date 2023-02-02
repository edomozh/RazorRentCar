namespace RentApp.Pages
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using RentApp.Data;
    using System.ComponentModel.DataAnnotations;

    public class CarModel : PageModel
    {
        readonly AppDbContext context;

        [BindProperty]
        public Car Car { get; set; } = new();

        [BindProperty]
        [DataType("month")]
        public DateTime Month { get; set; } = DateTime.Today;

        [BindProperty]
        [Display(Name = "Платежи")]
        public List<Payment> Payments { get; set; } = new();

        [BindProperty]
        [Display(Name = "Пробег")]
        public Mileage NewMileage { get; set; } = new();

        [BindProperty]
        [Display(Name = "Расход")]
        public Expense NewExpense { get; set; } = new();

        public CarModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGetAsync(ulong id)
        {
            Car = await context.Cars.AsNoTracking()
                .Include(c => c.Segment)
                .Include(c => c.Expenses)
                .FirstAsync(c => c.Id == id);

            Car.Contracts = await context.Contracts.AsNoTracking()
                .Include(r => r.Driver)
                .Include(r => r.Car)
                .Where(r => r.CarId == Car.Id)
                .Where(r => r.Start >= DateTime.Now.AddYears(-1))
                .OrderBy(r => r.Start)
                .ToListAsync();

            Payments = await context.Payments.AsNoTracking()
                .Include(p => p.Contract)
                .ThenInclude(c => c!.Driver)
                .Where(p => Car.Contracts.Select(c => c.Id).Contains(p.ContractId))
                .Where(p => p.Date.Year == Month.Year && p.Date.Month == Month.Month)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteCarAsync(ulong id)
        {
            Car = await context.Cars.FirstAsync(c => c.Id == id);

            context.Cars.Remove(Car);
            await context.SaveChangesAsync();

            return RedirectToPage("/Cars/Cars");
        }

        public async Task<IActionResult> OnPostMonthAsync()
        {
            return await OnGetAsync(Car.Id);
        }

        public async Task<IActionResult> OnPostAddMileageAsync()
        {
            NewMileage.CarId = Car.Id;
            context.Mileages.Add(NewMileage!);
            await context.SaveChangesAsync();

            return await OnGetAsync(Car.Id);
        }

        public async Task<IActionResult> OnPostAddExpenseAsync()
        {
            NewExpense.CarId = Car.Id;
            context.Expenses.Add(NewExpense!);
            await context.SaveChangesAsync();

            return await OnGetAsync(Car.Id);
        }
    }
}