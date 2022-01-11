using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(int colorId)
        {
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
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
