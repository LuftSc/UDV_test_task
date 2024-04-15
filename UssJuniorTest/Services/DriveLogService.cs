using UssJuniorTest.Abstractions;
using UssJuniorTest.Contracts;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Repositories;
using UssJuniorTest.Pagination;

namespace UssJuniorTest.Services
{
    /// <summary>
    /// Класс-сервис, реализующий логику по предоставлении информации о водителе, машине и времени его вождения.
    /// </summary>
    public class DriveLogService : IDriveLogService
    {
        private readonly DriveLogRepository _driveLogRepository;
        private readonly CarRepository _carRepository;
        private readonly PersonRepository _personRepository;
        public DriveLogService(
            DriveLogRepository driveLogRepository,
            CarRepository carRepository,
            PersonRepository personRepository)
        {
            _driveLogRepository = driveLogRepository;
            _carRepository = carRepository;
            _personRepository = personRepository;
        }
        public enum SortState
        {
            DriverNameAsc,
            DriverNameDesc,
            CarModelAsc,
            CarModelDesc,
            CarManufacturerAsc,
            CarManufacturerDesc,
        }
        private IEnumerable<DriveLogAggregation> GetDriveLogsInTimeInterval(
            DateTime startTime, 
            DateTime endTime)
        {
            var result = new List<DriveLogAggregation>();
            var allDriveLogs = _driveLogRepository.GetAll();

            foreach (var driveLog in allDriveLogs)
            {
                if (driveLog.StartDateTime >= startTime 
                    && driveLog.EndDateTime <= endTime)
                {
                    var person = _personRepository.Get(driveLog.PersonId);
                    var car = _carRepository.Get(driveLog.CarId);
                    result.Add(new DriveLogAggregation(result.Count, person, car, driveLog));
                }  
            }

            return result;
        }

        public PaginatedLogs GetLogsAggregation(
            DateTime startTime, 
            DateTime endTime, 
            string carModel = "", 
            string driverName = "",
            SortState sortOrder = SortState.DriverNameAsc,
            int page = 1,
            int logsPerPage = 10) 
        {
            var driveLogs = GetDriveLogsInTimeInterval(startTime, endTime)
                .Select(d => new DriveLogResponse(d.Id, d.Driver, d.Car, d.DrivingTime));

            driveLogs = FilterLogs(driveLogs, carModel, driverName);
            driveLogs = SortLogs(driveLogs, sortOrder);
            
            return PaginatedLogs.ToPaginatedLogs(driveLogs, page, logsPerPage);
        }

        public static IEnumerable<DriveLogResponse> FilterLogs(
            IEnumerable<DriveLogResponse> driveLogs, 
            string carModel, 
            string driverName)
        {
            if (!string.IsNullOrEmpty(carModel))
            {
                driveLogs = driveLogs
                    .Where(
                    d => d.car.Model.Contains(carModel) 
                    || d.car.Manufacturer.Contains(carModel));
            }
            if (!string.IsNullOrEmpty(driverName))
            {
                driveLogs = driveLogs
                    .Where(d => d.driver.Name.Contains(driverName));
            }

            return driveLogs;
        }
        public static IEnumerable<DriveLogResponse> SortLogs(
            IEnumerable<DriveLogResponse> driveLogs, 
            SortState sortOrder)
        {
            switch (sortOrder)
            {
                case SortState.DriverNameAsc:
                    driveLogs = driveLogs
                        .OrderBy(s => s.driver.Name);
                    break;
                case SortState.DriverNameDesc:
                    driveLogs = driveLogs
                        .OrderByDescending(s => s.driver.Name);
                    break;
                case SortState.CarModelAsc:
                    driveLogs = driveLogs
                        .OrderBy(s => s.car.Model);
                    break;
                case SortState.CarModelDesc:
                    driveLogs = driveLogs
                        .OrderByDescending(s => s.car.Model);
                    break;
                case SortState.CarManufacturerAsc:
                    driveLogs = driveLogs
                        .OrderBy(s => s.car.Manufacturer);
                    break;
                case SortState.CarManufacturerDesc:
                    driveLogs = driveLogs
                        .OrderByDescending(s => s.car.Manufacturer);
                    break;
                default:
                    driveLogs = driveLogs
                        .OrderBy(s => s.drivingTime);
                    break;
            }
            return driveLogs;
        }
    }
}
