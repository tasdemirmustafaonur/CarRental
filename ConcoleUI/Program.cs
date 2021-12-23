using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //BrandTest();
            //CarDelete();
            //CarAdd();
            //CarUpdate();
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { BrandId = 2, ColorId = 3, DailyPrice = 1300, ModelYear = "2006", Description = "Araç hakkında bilgi bulunmamaktadır." };
            carManager.Add(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car {CarId = 1002};
            carManager.Delete(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}  /  {1}",car.CarId,car.DailyPrice);
            }
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { CarId = 11, BrandId = 5,ModelYear = "2000"};
            carManager.Update(car1);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}",car.CarId,car.BrandId,car.ModelYear,car.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}  /  {1} / {2} / {3}",car.CarId,car.BrandName,car.ColorName,car.DailyPrice);
            }
        }
    }
}
