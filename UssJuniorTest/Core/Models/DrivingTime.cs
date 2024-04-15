namespace UssJuniorTest.Core.Models
{
    /// <summary>
    /// Класс для удобного представления времени вождения в днях,часах и минутах.
    /// </summary>
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
