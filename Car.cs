using SemesterWork2.Lookups;
using System;
using System.Collections.Generic;

namespace SemesterWork2
{
    public class Car
    {
        public Car(BrandInfo brandInfo,CarType carType, int seats, DoorsEnum doors, GearboxEnum gearboxType, EngineSpecification engine, List<Extra> extras)
        {
            BrandInfo = brandInfo;
            Type = carType;
            Seats = seats;
            Doors = doors;
            GearboxType = gearboxType;
            EngineSpecification = new EngineSpecification(engine);
            Extras = new List<Extra>(extras);
            Id = Guid.NewGuid();
        }
        
        public bool Availability = true;
        public Guid Id { get; set; }
        public BrandInfo BrandInfo { get; set; }
        public CarType Type { get; set; }
        public int Seats { get; set; }
        public DoorsEnum Doors { get; set; }
        public GearboxEnum GearboxType { get; set; }
        public EngineSpecification EngineSpecification { get; set; }
        public List<Extra> Extras { get; set; }
    }
}
