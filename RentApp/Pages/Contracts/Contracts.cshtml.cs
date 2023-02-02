namespace RentApp.Pages
{
    using RentApp.Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using RentApp.Data;

    public class ContractsModel : PageModel
    {
        public class ContractstatusComparer : Comparer<Contract>
        {
            public override int Compare(Contract? x, Contract? y)
            {
                if (x == null || y == null) return 0;
                return (int)((x.Start.AddDays(x.Payments.Count) - DateTime.Today).TotalDays - (y.Start.AddDays(y.Payments.Count) - DateTime.Today).TotalDays);
            }
        }

        readonly AppDbContext context;

        public List<Contract> Contracts { get; private set; } = new();

        public ContractsModel(AppDbContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Contracts = await context.Contracts.AsNoTracking().Include(c => c.Car).Include(c => c.Driver).Include(r => r.Payments).ToListAsync();
            Contracts.Sort(new ContractstatusComparer());
            return Page();
        }
    }
}