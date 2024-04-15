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

        public List<DriveLogAggregation> GetDriveLogsInTimeInterval(DateTime startTime, DateTime endTime)
        {
            var result = new List<DriveLogAggregation>();
            var allDriveLogs = _driveLogRepository.GetAll();

            foreach (var driveLog in allDriveLogs)
            {
                var person = _personRepository.Get(driveLog.PersonId);
                var car = _carRepository.Get(driveLog.CarId);

                result.Add(new DriveLogAggregation(person, car, driveLog));
            }

            return result;
        }
    }
}
