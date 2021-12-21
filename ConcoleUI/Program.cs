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
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.DailyPrice);
            //}

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            //foreach (var car in carManager.GetCarsByBrandId(2))
            //{
            //    Console.WriteLine(car.ModelYear);
            //}

            carManager.Add(new Car{BrandId = 3,ColorId = 4,DailyPrice = 900,ModelYear = "2021",Description = "çıtır hasarlı"});
        }
    }
}
