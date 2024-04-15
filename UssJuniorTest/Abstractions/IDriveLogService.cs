using UssJuniorTest.Core.Models;
using UssJuniorTest.Pagination;
using static UssJuniorTest.Services.DriveLogService;

namespace UssJuniorTest.Abstractions
{
    /// <summary>
    /// Интерфейс, предоставляющий возможность 
    /// взаимодействия с сервисом получения записей о вождении
    /// </summary>
    public interface IDriveLogService
    {
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
        /// <param name="page">Текущая страница</param>
        /// <param name="logsPerPage">Количество отображаемых логов на странице</param>
        /// <returns></returns>
        public PaginatedLogs GetLogsAggregation(
            DateTime startTime,
            DateTime endTime,
            string carModel = "",
            string driverName = "",
            SortState sortOrder = SortState.DriverNameAsc,
            int page = 1,
            int logsPerPage = 10);
    }
}