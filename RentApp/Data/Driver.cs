namespace RentApp.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Driver : BaseEntity
    {
        [Display(Name = "Имя")]
        public string? FirstName { get; set; } = string.Empty;

        [Display(Name = "Фамилия")]
        public string? LastName { get; set; } = string.Empty;

        [Display(Name = "Телефон")]
        public string? PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Долг")]
        public int Debt { get; set; }

        [NotMapped]
        [Display(Name = "Договоры")]
        public List<Contract> Contracts { get; set; } = new();

        [NotMapped]
        [Display(Name = "Имя")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        [NotMapped]
        [Display(Name = "Цвет")]
        public string Color { get { return Debt > 0 ? "danger" : "white"; } }
    }
}
