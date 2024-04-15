using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Contracts
{
    /// <summary>
    /// Объект, отправляемый в Swagger в качестве ответа.
    /// </summary>
    public record DriveLogResponse(
        long id,
        Person driver,
        Car car,
        DrivingTime drivingTime
        )
    {
    }
}
