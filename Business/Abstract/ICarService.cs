using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(int carId);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsWithDetails();
        IDataResult<CarDetailDto> GetCarDetails(int carId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandIdWithDetails(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorIdWithDetails(int colorId);

    }
}
