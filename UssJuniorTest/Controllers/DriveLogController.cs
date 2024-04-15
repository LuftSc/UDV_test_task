using Microsoft.AspNetCore.Mvc;
using UssJuniorTest.Abstractions;
using UssJuniorTest.Contracts;
using UssJuniorTest.Pagination;
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

    /// <summary>
    /// Получить записи о водителе(возраст и имя), 
    /// машине(модель,производитель) и времени вождения 
    /// машины в указанном временной диапазоне.
    /// </summary>
    /// <param name="startTime">Начальная дата</param>
    /// <param name="endTime">Конечная дата</param>
    /// <param name="carModel">Модель машины</param>
    /// <param name="driverName">Имя водителя</param>
    /// <param name="sortOrder">Параметр сортировки</param>
    /// <param name="pp">Параметры для пагинации</param>
    /// <returns></returns>

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