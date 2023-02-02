namespace RentApp.Data
{
    using System.ComponentModel.DataAnnotations;

    public class Car : BaseEntity
    {
        [Display(Name = "Название")]
        public string? Name { get; set; } = string.Empty;

        [Display(Name = "Название для клиента")]
        public string? PublicName { get; set; } = string.Empty;

        [Display(Name = "Тариф")]
        public string? Rate { get; set; } = string.Empty;

        [Display(Name = "Сегмент")]
        public ulong? SegmentId { get; set; }
        public SegmentItem? Segment { get; set; }

        [Display(Name = "Фото")]
        public ulong? PhotoId { get; set; }
        public Photo? Photo { get; set; }

        [Display(Name = "Цвет")]
        public string? Color { get; set; } = "#000000";

        [Display(Name = "Описание для клиента")]
        public string? PublicDescription { get; set; } = string.Empty;

        [Display(Name = "Архив")]
        public bool Archive { get; set; }

        [Display(Name = "Договоры")]
        public List<Contract> Contracts { get; set; } = new();

        [Display(Name = "Расходы")]
        public List<Expense> Expenses { get; set; } = new();

        [Display(Name = "История")]
        public List<MainHistory> History { get; set; } = new();

        [Display(Name = "Пробег")]
        public List<Mileage> Mileages { get; set; } = new();

        [Display(Name = "Настройки")]
        public List<Maintenance> Maintenances { get; set; } = new();
    }
}
