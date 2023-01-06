namespace DemidovPark.Pages
{
    using DemidovPark.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using System.Data;

    public class ContractModel : PageModel
    {
        readonly AppDbContext context;

        [BindProperty]
        public Contract Contract { get; set; } = new();

        [BindProperty]
        public int TotalDays
        {
            get
            {
                return (Contract.Finish.Date.AddDays(1) - Contract.Start.Date).Days;
            }
        }

        [BindProperty]
        public Payment NewPayment { get; set; } = new();

        [BindProperty]
        public Payment EditPayment { get; set; } = new();

        public List<Contract> Contracts { get; set; } = new();

        public ContractModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGetAsync(ulong id)
        {
            await LoadContract(id);
            return Page();
        }

        public async Task<IActionResult> OnPostCancelAsync()
        {
            await LoadContract(Contract.Id);
            if (Contract is null) return NotFound();

            if (Contract.Payments?.Count == 0)
            {
                context.Contracts.Remove(Contract);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("/Contracts/Contracts");
        }

        public async Task<IActionResult> OnPostFinishAsync()
        {
            if (Contract is null) return NotFound();
            await LoadContract(Contract.Id);

            Contract.Finished = true;
            context.Contracts.Update(Contract);
            await context.SaveChangesAsync();

            await LoadContract(Contract.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostNewPaymentAsync(int days)
        {
            await LoadContract(Contract.Id);

            var paymentDates = Contract.Payments.Select(p => p.Date);

            var allDates = Enumerable.Range(0, TotalDays).Select(i => Contract.Start.AddDays(i).Date);

            if (Contract.Endless)
                allDates = Enumerable.Range(0, paymentDates.Count() + 365).Select(i => Contract.Start.AddDays(i).Date);

            var missingDates = allDates.Except(paymentDates).Take(days);

            foreach (DateTime date in missingDates)
            {
                context.Payments.Add(
                    new Payment
                    {
                        ContractId = Contract.Id,
                        Date = date,
                        PaymentType = NewPayment.PaymentType,
                        PaymentDate = NewPayment.PaymentDate,
                        Paid = NewPayment.Paid,
                        Income = NewPayment.Income,
                        Debt = NewPayment.Debt

                    });
            }

            await context.SaveChangesAsync();

            await LoadContract(Contract.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostEditPaymentAsync(ulong id)
        {
            await LoadContract(Contract.Id);
            if (Contract is null) return NotFound();
            if (Contract.Payments is null) return NotFound();

            EditPayment = Contract.Payments.First(p => p.Id == id);
            return Page();
        }

        public async Task<IActionResult> OnPostDeletePaymentAsync(ulong id)
        {
            await LoadContract(Contract.Id);
            var payment = Contract.Payments.First(p => p.Id == id);
            context.Payments.Remove(payment);
            await context.SaveChangesAsync();
            await LoadContract(Contract.Id);
            return Page();
        }

        public async Task<IActionResult> OnPostSavePaymentAsync()
        {
            context.Payments.Update(EditPayment!);
            await context.SaveChangesAsync();
            await LoadContract(EditPayment.ContractId);
            EditPayment = new();
            return Page();
        }

        public async Task LoadContract(ulong id)
        {
            Contract = await context.Contracts.AsNoTracking()
                .Include(r => r.Driver)
                .Include(r => r.Car)
                .Include(r => r.Payments.OrderBy(y => y.Date))
                .FirstAsync(r => r.Id == id);
        }

        public async Task<IActionResult> OnPostSaveDebtAsync()
        {
            await LoadContract(Contract.Id);

            if (Contract == null) return NotFound();
            if (Contract.Driver == null) return NotFound();

            Contract.Driver.Debt += Contract.Payments.Select(p => p.Debt).Sum();

            context.Drivers.Update(Contract.Driver);

            foreach (var payment in Contract.Payments)
            {
                payment.Debt = 0;
                context.Payments.Update(payment);
            }

            await context.SaveChangesAsync();

            await LoadContract(Contract.Id);
            return Page();
        }

    }
}