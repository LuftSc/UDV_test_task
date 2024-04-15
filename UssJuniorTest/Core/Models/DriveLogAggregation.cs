﻿namespace UssJuniorTest.Core.Models
{
    public class DriveLogAggregation : Model
    {
        public DriveLogAggregation(Person person, Car car, DriveLog driveLog) 
        { 
            Driver = person;
            Car = car;

            var diff = driveLog.EndDateTime.Subtract(driveLog.StartDateTime);
            DrivingTime = new DrivingTime(diff);
        }

        public Person Driver { get;}
        public Car Car { get;}
        public DrivingTime DrivingTime { get;}  

    }
}
