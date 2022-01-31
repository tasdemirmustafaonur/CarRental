﻿using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetRentalById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetRentalsByCustomerIdWithDetails(int customerId);
        IDataResult<bool> CheckIfCanCarBeRentedNow(int carId);
        IDataResult<bool> CheckIfAnyReservationsBetweenSelectedDates(int carId, DateTime rentDate, DateTime returnDate);
        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
        IResult Add(Rental rental);
        IResult Delete(int rentalId);
        IResult Update(Rental rental);
    }
}
