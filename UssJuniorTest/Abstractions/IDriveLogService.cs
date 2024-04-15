using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Abstractions
{
    public interface IDriveLogService
    {
        public IEnumerable<DriveLogAggregation> GetLogsAggregation(
            DateTime startTime,
            DateTime endTime,
            string carModel = "",
            string driverName = "");
    }
}