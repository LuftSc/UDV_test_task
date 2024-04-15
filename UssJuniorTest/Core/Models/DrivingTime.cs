namespace UssJuniorTest.Core.Models
{
    public class DrivingTime
    {
        public int Days { get; }
        public int Hours { get; }
        public int Minutes { get; }

        public DrivingTime(TimeSpan time)
        {
            Days = time.Days;
            Hours = time.Hours;
            Minutes = time.Minutes;
        }
    }
}
