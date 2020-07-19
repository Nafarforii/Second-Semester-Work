using System.Collections.Generic;
using SemesterWork2.Lookups;
using System;
using System.Linq;

namespace SemesterWork2
{
    class Office
    {
        static void Main(string[] args)
        {
            #region Engines
                EngineSpecification DieselEngine = new EngineSpecification(2F, 200, FuelTypeEnum.Diesel);
                EngineSpecification ElectricEngine = new EngineSpecification(2.5F, 140, FuelTypeEnum.Electric);
                EngineSpecification LPGEngine = new EngineSpecification(3F, 170, FuelTypeEnum.LPG);
                EngineSpecification PetrolEngine = new EngineSpecification(2.7F, 120, FuelTypeEnum.Petrol);
                EngineSpecification LPGOrPetrolEngine = new EngineSpecification(2F, 230, FuelTypeEnum.LPGOrPetrol);
            #endregion
            #region Extras
                List<Extra> extras = new List<Extra>();
                extras.Add(new Extra("Air Conditioner"));
                extras.Add(new Extra("Interior Assistant"));
                extras.Add(new Extra("Adaptive LED headlights"));
                extras.Add(new Extra("Boot Opening"));
            #endregion
            #region Brands
                BrandInfo AudiA3 = new BrandInfo("Audi","A3");
                BrandInfo AudiA4 = new BrandInfo("Audi","A4");
                BrandInfo AudiA5 = new BrandInfo("Audi","A5");
                BrandInfo MercedesGLC = new BrandInfo("Mercedes","GLC");
                BrandInfo MercedesActros = new BrandInfo("Mercedes", "Actros");
                BrandInfo BMW_X5 = new BrandInfo("BMW", "X5");
                BrandInfo BMW_X6 = new BrandInfo("BMW", "X6");
                BrandInfo BMW_X7 = new BrandInfo("BMW", "X7");
            #endregion
            #region AllCars
                List<Car> AllAvailableCars = new List<Car>();
                AllAvailableCars.Add(new Car(AudiA3, CarType.Sedan, 4, DoorsEnum.Four, GearboxEnum.Automatic, DieselEngine, extras));
                AllAvailableCars.Add(new Car(AudiA4, CarType.Sedan, 4, DoorsEnum.Four, GearboxEnum.Automatic, LPGEngine, extras));
                AllAvailableCars.Add(new Car(AudiA5, CarType.Combi, 4, DoorsEnum.Two, GearboxEnum.Manual, PetrolEngine, extras));
                AllAvailableCars.Add(new Car(MercedesGLC, CarType.SUV, 4, DoorsEnum.Four, GearboxEnum.Combined, ElectricEngine, extras));
                AllAvailableCars.Add(new Car(MercedesActros, CarType.Truck, 2, DoorsEnum.Two, GearboxEnum.Manual, PetrolEngine, extras));
                AllAvailableCars.Add(new Car(BMW_X5, CarType.SUV, 4, DoorsEnum.Four, GearboxEnum.Manual, PetrolEngine, extras));
                AllAvailableCars.Add(new Car(BMW_X6, CarType.SUV, 4, DoorsEnum.Four, GearboxEnum.Combined, LPGOrPetrolEngine, extras));
                AllAvailableCars.Add(new Car(BMW_X7, CarType.SUV, 4, DoorsEnum.Four, GearboxEnum.Automatic, ElectricEngine, extras));
            #endregion
            #region Bookings
            List<Booking> AllBookings = new List<Booking>();
            #endregion
            
            do
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("To see the list of available cars, write:                          list                   ");
                Console.WriteLine("If you want to see more details about a car, write:                info {number from list}");
                Console.WriteLine("If you want to book a car, write:                                  book {number from list}");
                Console.WriteLine("-----------------------------------");


                var Reply = Console.ReadLine();
                var command = Reply.Split(' ')[0].ToLower();
                Console.WriteLine();
                if (AllAvailableCars.Count == 0)
                {
                    Console.WriteLine("Sorry for the inconvenience, but we don't have any cars right now!");
                    break;
                }
                
                if (command == "list")
                {
                    Console.WriteLine("This is a list of all of our cars:\n");
                    for (int i = 0; i < AllAvailableCars.Count; i++)
                    {
                        if (AllAvailableCars[i].Availability == false)
                        {
                            Console.WriteLine(i + 1 + "." + AllAvailableCars[i].BrandInfo.Brand + " " + AllAvailableCars[i].BrandInfo.Model + " " + AllAvailableCars[i].Type + " | Unavailable");
                        }
                        else
                        {
                            Console.WriteLine(i + 1 + "." + AllAvailableCars[i].BrandInfo.Brand + " " + AllAvailableCars[i].BrandInfo.Model + " " + AllAvailableCars[i].Type + " | Available");
                        }
                    }
                }

                if (command == "info")
                {
                    int Num = 0;
                    if (Reply == "info")
                    {
                        Console.WriteLine("This isn't a valid number from the list!");
                        continue;
                    }

                        try
                    {
                        Num = int.Parse(Reply.Split(' ')[1]);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"{(Reply.Split(' ')[1])} isn't a valid number!");
                        continue;
                    }

                    if (Num > AllAvailableCars.Count || Num < 1)
                    {
                        Console.WriteLine("There isn't a car with that number!\n\n");
                        continue;
                    }
                    Console.WriteLine("Brand: " + AllAvailableCars[Num - 1].BrandInfo.Brand + " | Model: " + AllAvailableCars[Num - 1].BrandInfo.Model + " | Type: " + AllAvailableCars[Num - 1].Type);
                    Console.WriteLine("Doors: " + AllAvailableCars[Num - 1].Doors);
                    Console.WriteLine("Seats: " + AllAvailableCars[Num - 1].Seats);
                    Console.WriteLine("Engine capacity: " + AllAvailableCars[Num - 1].EngineSpecification.Capacity + " | Car Horse Power: " + AllAvailableCars[Num - 1].EngineSpecification.HorsePowers + " | Fuel Type: " + AllAvailableCars[Num - 1].EngineSpecification.FuelType);
                    Console.WriteLine("Gear type: " + AllAvailableCars[Num - 1].GearboxType);
                    Console.Write("All included extras: ");
                    foreach (var item in AllAvailableCars[Num - 1].Extras)
                    {
                        Console.Write(item.ExtraType + " | ");
                    }Console.WriteLine();
                }
            
                if (command == "book")
                {
                    int Num = 0;
                    if (Reply == "book")
                    {
                        Console.WriteLine("This isn't a valid number from the list!");
                        continue;
                    }

                        try
                        {
                            Num = int.Parse(Reply.Split(' ')[1]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{(Reply.Split(' ')[1])} isn't a valid number!");
                            continue;
                        }

                    if (Num > AllAvailableCars.Count || Num < 1)
                    {
                        Console.WriteLine("There isn't a car with that number!\n\n");
                        continue;
                    }
                    if (AllAvailableCars[Num-1].Availability == false)
                    {      
                        var book = AllBookings.First(b=>b.BookedCar.Id == AllAvailableCars[Num-1].Id);
                        Console.WriteLine($"This car has already been booked! It'll be available after {book.GetReturnDate()}\n\n");
                        continue;
                    }
                    #region RentalInfo/booking Background
                    Console.Write("When do you want the car? (dd,hh,mm) ");
                        var StartDateBeforeSplit = Console.ReadLine();
                        var startDays = int.Parse(StartDateBeforeSplit.Split(",")[0]);
                        var startHours = int.Parse(StartDateBeforeSplit.Split(",")[1]);
                        var startMins = int.Parse(StartDateBeforeSplit.Split(",")[2]);
                        var StartDate = new DateTime(DateTime.Now.Year,DateTime.Now.Month,startDays,startHours,startMins,0);
                    Console.Write("For how long do you intend to have the car? (dd,hh,mm) ");
                        var TimeForThePersonToHaveTheCar = Console.ReadLine();
                        var days = int.Parse(TimeForThePersonToHaveTheCar.Split(',')[0]);
                        var hours = int.Parse(TimeForThePersonToHaveTheCar.Split(',')[1]);
                        var minutes = int.Parse(TimeForThePersonToHaveTheCar.Split(',')[2]);
                        var Period = new TimeSpan(days, hours, minutes,0);
                    decimal PricePerDay = 0;
                    if (AllAvailableCars[Num - 1].BrandInfo.Brand == "Audi")
                        PricePerDay = 20;
                    if (AllAvailableCars[Num - 1].BrandInfo.Brand == "Mercedes")
                        PricePerDay = 35;
                    if (AllAvailableCars[Num - 1].BrandInfo.Brand == "BMW")
                        PricePerDay = 25;
                        decimal Price = PricePerDay * Period.Days;
                            if (Period.Hours >= 12 && Period.Minutes > 0 || Period.Hours > 12)
                            {
                                Price += PricePerDay;
                            }
                        Console.Write("Do you have any additional requests? (y/n) ");
                        var answer = Console.ReadLine();
                        string AditionalRequests = "No additional requests!";
                            if (answer == "y")
                            {
                                Console.Write("         Provide your additional requests: ");
                                AditionalRequests = Console.ReadLine();
                            }
                    Console.Write($"Your final price will be {Price}лв.\nAre you sure you want to continue? (y/n) ");
                        answer = Console.ReadLine();
                        if (answer == "n")
                        {
                        Console.WriteLine("\nYou have terminated your order!\n");
                        continue;
                        }
                    #endregion
                    RentalInfo RentalInformation = new RentalInfo(Period,Price);
                    Booking booking = new Booking(StartDate, AditionalRequests, AllAvailableCars[Num - 1], RentalInformation);
                    Console.WriteLine($"\n\nCongratulations! You have booked our {booking.BookedCar.BrandInfo.Brand} {booking.BookedCar.BrandInfo.Model} from {booking.StartDate} until {booking.GetReturnDate()}");
                    Console.WriteLine($"Additional requests: {booking.ClientAdditionalInformation}");
                    Console.WriteLine($"The price is: {booking.RentalInfo.Price}лв.");
                    AllAvailableCars[Num - 1].Availability = false;
                    AllBookings.Add(booking);
                }
                Console.WriteLine("\n");
            } while (true);
        }
    }
}
