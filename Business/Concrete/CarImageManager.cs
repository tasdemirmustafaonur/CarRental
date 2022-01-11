﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

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
            var checkIfCarImage = CheckIfCarImage(carId);
            var images = checkIfCarImage.Success
                ? checkIfCarImage.Data
                : _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(images, Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId),
                Messages.CarImageListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int imageId)
        {
            var image = _carImageDal.Get(c => c.CarImageId == imageId);
            if (image == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            var result = FileHelper.Delete(image.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeletingImage);
            }
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IDataResult<List<CarImage>> CheckIfCarImage(int carId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                List<CarImage> imageList = new List<CarImage>();
                imageList.Add(new CarImage
                {
                    ImagePath = logoPath,
                    CarId = carId,
                    Date = DateTime.Now
                });
                return new SuccessDataResult<List<CarImage>>(imageList);
            }
            return new ErrorDataResult<List<CarImage>>(new List<CarImage>());
        }
    }
}
