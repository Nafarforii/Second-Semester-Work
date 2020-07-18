using SemesterWork2.Lookups;

namespace SemesterWork2
{
    public class EngineSpecification
    {
        public EngineSpecification(EngineSpecification engineSpecification)
        {
            Capacity = engineSpecification.Capacity;
            HorsePowers = engineSpecification.HorsePowers;
            FuelType = engineSpecification.FuelType;

        }
        public EngineSpecification(float capacity,int horsePower,FuelTypeEnum fuelType)
        {
            Capacity = capacity;
            HorsePowers = horsePower;
            FuelType = fuelType;
        }
        public float Capacity { get; }
        public int HorsePowers { get; }
        public FuelTypeEnum FuelType { get; }
    }
}
