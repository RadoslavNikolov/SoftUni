namespace Huy_Phuong.Helpers.Validators
{
    using System.Linq;
    using Custom_Exceptions;
    using Infrastructure;

    public static class ValidatePerformances
    {
        public static void ValidateForOverlap(ITheatre theatre, IPerformance performance)
        {
            var performanceStart = performance.StartTime;
            var performanceEnd = performanceStart + performance.Duration;

            if (theatre.Performances.Any(p => p.StartTime <= performanceEnd && performanceStart <= (p.StartTime + p.Duration)))
            {
                throw new TimeDurationOverlapException("Error: Time/duration overlap");
            }
        }
    }
}