using System;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManagerAddTest();
            //UserManagerAddTest();
            //RentalCarTest();
            //CarTest();
            //BrandTest();
            //CarDelete();
            //CarAdd();
            //CarUpdate();
        }


        private static void RentalCarTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var x = rentalManager.Add(new Rental {CarId = 4, CustomerId = 1, RentDate = DateTime.Now});
            Console.WriteLine("{0} -----> {1}",x.Success,x.Message);
        }

        private static void CustomerManagerAddTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer {UserId = 5, CompanyName = "Koç"});
        }

        private static void UserManagerAddTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User {FirstName = "Enes", LastName = "Koç", Email = "enes@"});
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { BrandId = 2, ColorId = 3, DailyPrice = 1300, ModelYear = 2006, Description = "Araç hakkında bilgi bulunmamaktadır." };
            carManager.Add(car1);

            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car {Id = 1002};
            carManager.Delete(car1.Id);

            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}  /  {1}", car.Id, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car { Id = 11, BrandId = 5,ModelYear = 2000};
            carManager.Update(car1);

            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} / {1} / {2} / {3}", car.Id, car.BrandId, car.ModelYear, car.DailyPrice);
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
                    Console.WriteLine(brand.Name);
                }
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}  /  {1} / {2} / {3} / {4}", car.Id, car.BrandName, car.ModelName, car.ColorName, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }
    }
}
