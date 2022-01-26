﻿using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id
                    select new CarDetailDto
                    {
                        Id = c.Id, BrandName = b.Name,ModelName = c.ModelName, ColorName = co.Name,DailyPrice = c.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
