using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,CarRentalContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalsDto()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                    join c in context.Cars
                        on r.CarId equals c.CarId
                    join cu in context.Customers
                        on r.CustomerId equals cu.CustomerId
                    select new RentalDetailDto
                    {
                        RentalId = r.RentalId,
                        DailyPrice = c.DailyPrice,
                        RentDate = r.RentDate.Value,
                        ReturnDate = r.ReturnDate.Value
                    };
                return result.ToList();
            }
        }
    }
}
