using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsImagesListed);
        }

        public IDataResult<List<CarImage>> GetCarImages(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId),
                Messages.CarImageListed);
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int imageId)
        {
            throw new NotImplementedException();
        }
    }
}
