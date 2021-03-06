using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1,BrandId = 1,ColorId = 1,ModelYear = 2006,DailyPrice = 100000,Description = "Çıtır Hasarlı"},
                new Car{Id = 2,BrandId = 1,ColorId = 1,ModelYear = 2010,DailyPrice = 150000,Description = "Çıtır Hasarlı"},
                new Car{Id = 3,BrandId = 2,ColorId = 2,ModelYear = 2011,DailyPrice = 180000,Description = "Çıtır Hasarlı"},
                new Car{Id = 4,BrandId = 2,ColorId = 2,ModelYear = 2015,DailyPrice = 200000,Description = "Çıtır Hasarlı"},
                new Car{Id = 5,BrandId = 3,ColorId = 3,ModelYear = 2020,DailyPrice = 250000,Description = "Çıtır Hasarlı"},
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return (Car)_cars.Where(c => c.Id == id);
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetAllByColor(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
