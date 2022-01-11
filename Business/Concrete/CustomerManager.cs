using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
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
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<Customer> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId),
                Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomersDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetail(),
                Messages.CustomersListed);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfUserIdExist(customer.UserId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(int customerId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCustomerIdExist(customerId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            var deletedCustomer = _customerDal.Get(c => c.CustomerId == customerId);
            _customerDal.Delete(deletedCustomer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfCustomerIdExist(customer.CustomerId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        private IResult CheckIfCustomerIdExist(int customerId)
        {
            var result = _customerDal.GetAll(c => c.CustomerId == customerId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.CustomerNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUserIdExist(int userId)
        {
            var result = _customerDal.GetAll(c => c.UserId == userId).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyCustomer);
            }
            return new SuccessResult();
        }
    }
}
