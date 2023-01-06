namespace DemidovPark.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public ulong Id { get; set; }

        [Display(Name = "Создано")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Изменено")]
        public string? UpdatedBy { get; set; }

        [Display(Name = "Дата изменения")]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Комментарий")]
        public string? Comment { get; set; }
    }
}
