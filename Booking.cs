using System;

namespace SemesterWork2
{
    public class Booking
    {
        public Booking(DateTime startDate, string clientRequestInfo, Car carToBook, RentalInfo rentalInformation)
        {
            StartDate = startDate;
            ClientAdditionalInformation = clientRequestInfo;
            BookedCar = carToBook;
            RentalInfo = rentalInformation;
        }
        public DateTime StartDate { get; set; }
        public string ClientAdditionalInformation { get; set; }
        public Car BookedCar { get; set; }
        public RentalInfo RentalInfo { get; set; }
        public DateTime GetReturnDate()
        {
            return this.StartDate.Add(RentalInfo.Period);
        }
    }
}
