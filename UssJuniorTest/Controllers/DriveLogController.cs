using Microsoft.AspNetCore.Mvc;
using UssJuniorTest.Abstractions;
using UssJuniorTest.Contracts;
using static UssJuniorTest.Services.DriveLogService;

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
    public List<DriveLogResponse> GetDriveLogsAggregation(
        DateTime startTime, 
        DateTime endTime, 
        string carModel, 
        string driverName,
        SortState sortOrder)
    {
        var driveLogsAggregation = _driveLogService
            .GetLogsAggregation(startTime, endTime, carModel, driverName, sortOrder);

        return driveLogsAggregation
            .Select(d => new DriveLogResponse(d.Id, d.Driver, d.Car, d.DrivingTime))
            .ToList();
    }
}