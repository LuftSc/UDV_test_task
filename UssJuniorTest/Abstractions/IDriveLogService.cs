using UssJuniorTest.Core.Models;
using static UssJuniorTest.Services.DriveLogService;

namespace UssJuniorTest.Abstractions
{
    public interface IDriveLogService
    {
        public IEnumerable<DriveLogAggregation> GetLogsAggregation(
            DateTime startTime,
            DateTime endTime,
            string carModel = "",
            string driverName = "",
            SortState sortOrder = SortState.DriverNameAsc);
    }
}