namespace RentApp.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Request : BaseEntity
    {
        [Display(Name = "Авто")]
        public ulong? CarId { get; set; }
        public Car? Car { get; set; }

        [Display(Name = "От")]
        public DateTime Start { get; set; } = DateTime.Today.AddHours(DateTime.Now.Hour);

        [Display(Name = "До")]
        public DateTime Finish { get; set; } = DateTime.Today.AddDays(1).AddHours(12);

        [Display(Name = "Телефон")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Дальность")]
        public ulong DistanceId { get; set; }
        public DistanceItem? Distance { get; set; }

        [Display(Name = "Обработанна")]
        public bool Processed { get; set; }
    }
}
