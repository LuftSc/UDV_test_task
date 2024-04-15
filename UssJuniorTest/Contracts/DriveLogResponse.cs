using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Contracts
{
    public record DriveLogResponse(
        long id,
        Person driver,
        Car car,
        DrivingTime drivingTime
        )
    {
    }
}
