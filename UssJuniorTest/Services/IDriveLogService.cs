using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Services
{
    public interface IDriveLogService
    {
        List<DriveLogAggregation> GetDriveLogsInTimeInterval(DateTime startTime, DateTime endTime);
    }
}