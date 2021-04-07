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
            //CarDetails();
            //UserAddTest();

            RentalTest();



        }

        private static void UserAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User { FirstName = "Ali", LastName = "Yılmaz", Id = 80, /*Password = "147258"*/ };

            if (userManager.Add(user).Success )
            {
                userManager.Add(user);

            }
            else
            {
                Console.WriteLine(userManager.Add(user).Message);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental
            {
                CarId = 20,
                RentDate = DateTime.Now,
                CustomerId = 45,
                ReturnDate = DateTime.Now.AddDays(5),
                Id = 300
            };

            if (rentalManager.Add(rental).Success)
            {
                rentalManager.Add(rental);
            }
            else
            {
                Console.WriteLine(rentalManager.Add(rental).Message);
            }
        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarName = "Opel", BrandId = 14, ColorId = 24, DailyPrice = 500, ModelYear = 2004, Description = "Kiralık Opel", Id = 5 });
        }

        private static void CarGetByBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetCarsByBrandId(12).Data);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success==true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName + "/" + color.ColorId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName + "/" + brand.BrandId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                CarName = "Lada",
                BrandId = 58,
                ColorId = 34,
                DailyPrice = 200,
                ModelYear = 1997
            });
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"Car Name:{car.CarName}\nDaily Price:{car.DailyPrice}");
                Console.WriteLine("---------------------------------------------------------");
            }
        }

        private static void CarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                Console.WriteLine(result.Message);
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Car Name:{car.CarName}\nBrand Name:{car.BrandName}\nColor Name:{car.ColorName}\nDaily Price:{car.DailyPrice}");
                    Console.WriteLine("---------------------------------------------------------");
                    
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }


    }

}

