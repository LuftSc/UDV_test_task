using UssJuniorTest.Abstractions;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Repositories;

namespace UssJuniorTest.Services
{
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

        public IEnumerable<DriveLogAggregation> GetLogsAggregation(
            DateTime startTime, 
            DateTime endTime, 
            string carModel = "", 
            string driverName = "",
            SortState sortOrder = SortState.DriverNameAsc) 
        {
            var driveLogs = GetDriveLogsInTimeInterval(startTime, endTime);

            driveLogs = FilterLogs(driveLogs, carModel, driverName);
            driveLogs = SortLogs(driveLogs, sortOrder);
            
            return driveLogs;
        }

        public static IEnumerable<DriveLogAggregation> FilterLogs(
            IEnumerable<DriveLogAggregation> driveLogs, 
            string carModel, 
            string driverName)
        {
            if (!string.IsNullOrEmpty(carModel))
            {
                driveLogs = driveLogs
                    .Where(
                    d => d.Car.Model.Contains(carModel) 
                    || d.Car.Manufacturer.Contains(carModel));
            }
            if (!string.IsNullOrEmpty(driverName))
            {
                driveLogs = driveLogs
                    .Where(d => d.Driver.Name.Contains(driverName));
            }

            return driveLogs;
        }

        public static IEnumerable<DriveLogAggregation> SortLogs(
            IEnumerable<DriveLogAggregation> driveLogs, 
            SortState sortOrder)
        {
            switch (sortOrder)
            {
                case SortState.DriverNameAsc:
                    driveLogs = driveLogs
                        .OrderBy(s => s.Driver.Name);
                    break;
                case SortState.DriverNameDesc:
                    driveLogs = driveLogs
                        .OrderByDescending(s => s.Driver.Name);
                    break;
                case SortState.CarModelAsc:
                    driveLogs = driveLogs
                        .OrderBy(s => s.Car.Model);
                    break;
                case SortState.CarModelDesc:
                    driveLogs = driveLogs
                        .OrderByDescending(s => s.Car.Model);
                    break;
                case SortState.CarManufacturerAsc:
                    driveLogs = driveLogs
                        .OrderBy(s => s.Car.Manufacturer);
                    break;
                case SortState.CarManufacturerDesc:
                    driveLogs = driveLogs
                        .OrderByDescending(s => s.Car.Manufacturer);
                    break;
                default:
                    driveLogs = driveLogs
                        .OrderBy(s => s.DrivingTime);
                    break;
            }
            return driveLogs;
        }
    }
}
