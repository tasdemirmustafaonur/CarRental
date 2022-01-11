﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
            var checkIfCarImage = CheckIfCarHasImage(carId);
            var images = checkIfCarImage.Success
                ? _carImageDal.GetAll(c => c.CarId == carId)
                : checkIfCarImage.Data;
            return new SuccessDataResult<List<CarImage>>(images, checkIfCarImage.Message);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId),
                Messages.CarImageListed);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCarImageIdExist(carImage.CarImageId),CheckIfCarImageLimitExceeded(carImage.CarId));
            if (rulesResult != null)
            {
                return rulesResult;
            }

            var updatedImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            var result = FileHelper.Update(file, updatedImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorUpdatingImage);
            }
            carImage.ImagePath = result.Message;
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(int imageId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCarImageIdExist(imageId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }

            var deletedImage = _carImageDal.Get(c => c.CarImageId == imageId);
            var result = FileHelper.Delete(deletedImage.ImagePath);
            if (!result.Success)
            {
                return new ErrorResult(Messages.ErrorDeletingImage);
            }
            _carImageDal.Delete(deletedImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            int result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarHasImage(int carId)
        {
            string logoPath = "/images/default.jpg";
            bool result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                List<CarImage> imageList = new List<CarImage>
                {
                    new CarImage
                    {
                        ImagePath = logoPath,
                        CarId = carId,
                        Date = DateTime.Now
                    }
                };
                return new ErrorDataResult<List<CarImage>>(imageList, Messages.GetDefaultImage);
            }
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>(),Messages.CarImagesListed);
        }

        private IResult CheckIfCarImageIdExist(int imageId)
        {
            var result = _carImageDal.GetAll(c => c.CarImageId == imageId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CarImageIdNotExist);
            }
            return new SuccessResult();
        }
    }
}
