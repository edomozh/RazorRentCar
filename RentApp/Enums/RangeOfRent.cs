namespace RentApp.Enums
{
    using System.ComponentModel;

    public enum RangeOfRent
    {
        [Description("Город")]
        City,
        [Description("Город и область")]
        CityAndRegion,
        [Description("За пределы области")]
        OutOfRegion,
        [Description("Смешанная")]
        Mixed
    }
}
