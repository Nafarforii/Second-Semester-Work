using System;

namespace SemesterWork2
{
    public class RentalInfo
    {
        public RentalInfo(TimeSpan period, decimal price)
        {
            Period = period;
            Price = price;
        }
        public TimeSpan Period { get; }
        public decimal Price { get; }
    }
}
