namespace DemidovPark.Data
{
    using DemidovPark.Helpers;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Payment : BaseEntity
    {
        [Display(Name = "Аренда")]
        public ulong ContractId { get; set; }
        public Contract? Contract { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Дата оплаты")]
        public string? PaymentDate { get; set; } = string.Empty;

        [Display(Name = "Вид оплаты")]
        public string? PaymentType { get; set; } = string.Empty;

        [Display(Name = "Оплачено")]
        public string? Paid { get; set; } = string.Empty;

        [Display(Name = "Доход инвестора")]
        public int Income { get; set; }

        [Display(Name = "Мой доход")]
        [NotMapped]
        public int MyIncome { get { return Paid!.Calc() - Income; } }

        [Display(Name = "Долг")]
        public int Debt { get; set; }
    }
}
