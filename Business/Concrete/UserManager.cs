﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId), Messages.UserListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfEmailExist(user.Email));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int userId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfUserIdExist(userId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            var deletedUser = _userDal.Get(u => u.UserId == userId);
            _userDal.Delete(deletedUser);
            return new SuccessResult(Messages.UserDeleted);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfUserIdExist(user.UserId), CheckIfEmailExist(user.Email));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        private IResult CheckIfUserIdExist(int userId)
        {
            var result = _userDal.GetAll(u => u.UserId == userId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.UserNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmailExist(string userEmail)
        {
            var result = _userDal.GetAll(u => u.Email == userEmail).Any();
            if (result)
            {
                return new ErrorResult(Messages.UserEmailExist);
            }
            return new SuccessResult();
        }
    }
}
