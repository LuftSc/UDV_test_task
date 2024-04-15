using Microsoft.AspNetCore.Mvc;
using UssJuniorTest.Contracts;
using UssJuniorTest.Services;

namespace UssJuniorTest.Controllers;

[Route("api/driveLog")]
public class DriveLogController : ControllerBase
{
    private readonly IDriveLogService _driveLogService;
    public DriveLogController(IDriveLogService driveLogService)
    {
        _driveLogService = driveLogService;
    }

    [HttpGet]
    public List<DriveLogResponse> GetDriveLogsAggregation(DateTime startTime, DateTime endTime)
    {
        var driveLogsAggregation = _driveLogService.GetDriveLogsInTimeInterval(startTime, endTime);

        return driveLogsAggregation.Select(d => new DriveLogResponse(d.Id, d.Driver, d.Car, d.DrivingTime)).ToList();
    }
}