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
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfColorNameExist(color.ColorName));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(int colorId)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfColorIdExist(colorId));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            var deletedColor = _colorDal.Get(c => c.ColorId == colorId);
            _colorDal.Delete(deletedColor);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<Color> GetColorById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), Messages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            IResult rulesResult = BusinessRules.Run(CheckIfColorIdExist(color.ColorId), CheckIfColorNameExist(color.ColorName));
            if (rulesResult!=null)
            {
                return rulesResult;
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        private IResult CheckIfColorIdExist(int colorId)
        {
            var result = _colorDal.GetAll(c => c.ColorId == colorId).Any();
            if (!result)
            {
                return new ErrorResult(Messages.ColorNotExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfColorNameExist(string colorName)
        {
            var result = _colorDal.GetAll(c => c.ColorName == colorName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ColorNameExist);
            }
            return new SuccessResult();
        }
    }
}
