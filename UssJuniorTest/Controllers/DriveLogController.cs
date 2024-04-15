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
    public PaginatedLogs GetDriveLogsAggregation(
        DateTime startTime, 
        DateTime endTime, 
        string carModel, 
        string driverName,
        SortState sortOrder,
        PaginationParams pp)
    {
        return _driveLogService
            .GetLogsAggregation(startTime, endTime, carModel, driverName, sortOrder, pp.Page, pp.LogsPerPage);
    }
}