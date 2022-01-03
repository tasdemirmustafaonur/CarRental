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
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarRentalContext>,ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.UserId
                    select new CustomerDetailDto
                    {
                        CustomerId = c.CustomerId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        CompanyName = c.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
