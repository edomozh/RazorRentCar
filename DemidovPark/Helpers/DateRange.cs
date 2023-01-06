namespace DemidovPark.Helpers
{
    public class DateRange
    {
        public static bool IntersectionRanges(DateTime start1, DateTime finish1, DateTime start2, DateTime finish2)
        {
            var result = (start1 <= start2 && start2 <= finish1) ||
                         (start1 <= finish2 && finish2 <= finish1) ||
                         (start2 <= start1 && start1 <= finish2) ||
                         start2 <= finish1 && finish1 <= finish2;
            return result;
        }
    }
}
