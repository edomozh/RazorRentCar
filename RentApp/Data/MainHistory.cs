namespace RentApp.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MainHistory : BaseEntity
    {
        [Display(Name = "Параметр")]
        public ulong MaintenanceId { get; set; }
        public Maintenance? Maintenance { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Display(Name = "Пробег")]
        public int Mileage { get; set; }

        [Display(Name = "Ждем")]
        public int Next { get; set; }
    }
}
