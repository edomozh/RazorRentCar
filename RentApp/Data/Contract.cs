namespace RentApp.Data
{
    using RentApp.Helpers;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Contract : BaseEntity
    {
        [NotMapped]
        [Display(Name = "Аренда")]
        public string? ViewName { get { return $"{Car?.Name} - {Driver?.FullName}"; } }

        [Display(Name = "Водитель")]
        public ulong? DriverId { get; set; }
        public Driver? Driver { get; set; }

        [Display(Name = "Авто")]
        public ulong CarId { get; set; }
        public Car? Car { get; set; }

        [Display(Name = "От")]
        public DateTime Start { get; set; } = DateTime.Today.AddHours(DateTime.Now.Hour);

        [Display(Name = "До")]
        public DateTime Finish { get; set; } = DateTime.Today.AddDays(1).AddHours(12);

        [Display(Name = "Безсрочный договор")]
        public bool Endless { get; set; }

        [Display(Name = "Залог")]
        public string? Deposit { get; set; } = "0";

        [Display(Name = "Штраф")]
        public string? Penalty { get; set; } = "0";

        [Display(Name = "Платежи")]
        public List<Payment> Payments { get; set; } = new();

        [NotMapped]
        [Display(Name = "Долг")]
        public int? Debt { get { return Payments?.Sum(p => p.Debt); } }

        [NotMapped]
        [Display(Name = "Статус")]
        public string Status
        {
            get
            {
                return Finished ? "secondary" :
                       Start > DateTime.Today.AddDays(1) ? "primary" :
                       (Start.AddDays(Payments.Count) - DateTime.Today).Days > 3 ? "success" :
                       (Start.AddDays(Payments.Count) - DateTime.Today).Days > 0 ? "warning" :
                       (Start.AddDays(Payments.Count) - DateTime.Today).Days == 0 ? "orange" :
                       (Start.AddDays(Payments.Count) - DateTime.Today).Days < 0 ? "danger" :
                       "white";
            }
        }

        [Display(Name = "Завершена")]
        public bool Finished { get; set; }
    }
}
