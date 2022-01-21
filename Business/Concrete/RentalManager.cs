﻿using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [SecuredOperation("admin,rental.all,rental.list")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [SecuredOperation("admin,rental.all,rental.list")]
        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.RentalListed);
        }

        [SecuredOperation("admin,rental.all,rental.list")]
        public IDataResult<List<Rental>> GetCanBeRented()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate < DateTime.Now.Date),
                Messages.RentalsListed);
        }

        [SecuredOperation("admin,rental.all,rental.list")]
        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalsDto(), Messages.RentalsListed);
        }

        [SecuredOperation("admin,rental.all,rental.add")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (!IsCarAvailable(rental))
            {
                return new ErrorResult(Messages.RentalCarNotAvailable);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("admin,rental.all,rental.delete")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(int rentalId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfRentalIdExist(rentalId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            var deletedRental = _rentalDal.Get(r => r.Id == rentalId);
            _rentalDal.Delete(deletedRental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [SecuredOperation("admin,rental.all,rental.update")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfRentalIdExist(rental.Id));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private bool IsCarAvailable(Rental rental)
        {
            return !(_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null).Any());
        }

        private IResult CheckIfRentalIdExist(int rentalId)
        {
            var result = _rentalDal.GetAll(r => r.Id == rentalId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.RentalNotExist);
            }

            return new SuccessResult();
        }
    }
}
