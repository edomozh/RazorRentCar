namespace RentApp.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Maintenance : BaseEntity
    {
        [Display(Name = "Авто")]
        public ulong CarId { get; set; }
        public Car? Car { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string? Name { get; set; } = string.Empty;

        [Display(Name = "Описание")]
        public string? Descr { get; set; } = string.Empty;

        [Display(Name = "Шаг")]
        public int MileageStep { get; set; }
    }
}
