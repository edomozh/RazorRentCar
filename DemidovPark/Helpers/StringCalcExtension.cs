namespace DemidovPark.Helpers
{
    using System.Data;

    public static class StringCalcExtension
    {
        public static int Calc(this string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            var dt = new DataTable();

            return (int)dt.Compute(s, "");
        }
    }
}
