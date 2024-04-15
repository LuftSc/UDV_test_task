namespace UssJuniorTest.Core.Models
{
    public class DriveLogAggregation
    {
        public DriveLogAggregation(long id, Person person, Car car, DriveLog driveLog) 
        {
            Id = id;
            Driver = person;
            Car = car;

            var diff = driveLog.EndDateTime.Subtract(driveLog.StartDateTime);
            DrivingTime = new DrivingTime(diff);
        }
        
        public long Id { get; set; }
        public Person Driver { get;}
        public Car Car { get;}
        public DrivingTime DrivingTime { get;}  

    }
}
