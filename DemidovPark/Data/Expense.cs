namespace DemidovPark.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Expense : BaseEntity
    {
        [Display(Name = "Авто")]
        public ulong CarId { get; set; }
        public Car? Car { get; set; }

        [Display(Name = "Оплачено")]
        public int Value { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
