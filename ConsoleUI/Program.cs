using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car newCar = new Car
            {
                BrandId = 7,
                ColorId = 18,
                DailyPrice = 1800,
                Description = "Toyota",
                ModelYear = 2017,
            };
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            carManager.Add(newCar);
            
        }
    }
}
