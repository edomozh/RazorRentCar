namespace RentApp.Enums
{
    using System.ComponentModel;

    public enum CarClass
    {
        [Description("Инвестор")]
        investor,
        [Description("ДемидовПарк")]
        park,
        [Description("Премиум")]
        vip,
        [Description("Комфорт")]
        comfort
    };

}
