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
            
            //CarAddTest();
            //BrandTest();
            //ColorTest();
            //CarGetByBrandIdTest();
            //CarDeleteTest();
            CarDetails();
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarName = "Opel", BrandId = 14, ColorId = 24, DailyPrice = 500, ModelYear = 2004, Description = "Kiralık Opel", Id = 5 });
        }

        private static void CarGetByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetCarsByBrandId(12).CarName);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName + "/" + color.ColorId);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName + "/" + brand.BrandId);
            }
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                CarName = "Fiat",
                BrandId = 10,
                ColorId = 24,
                DailyPrice = 350,
                ModelYear = 2007
            });
        }

        private static CarManager CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"Car Name:{car.CarName}\nBrand Name:{car.BrandName}\nColor Name:{car.ColorName}\nDaily Price:{car.DailyPrice}");
                Console.WriteLine("---------------------------------------------------------");
            }

            return carManager;
        }


    }

}

