using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Contracts
{
    public record DriveLogResponse(
        Person driver,
        Car car,
        DrivingTime drivingTime
        )
    {
    }
}
