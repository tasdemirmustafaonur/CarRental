using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.BrandId).GreaterThan(0);

            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ColorId).GreaterThan(0);

            RuleFor(c => c.ModelName).NotEmpty();
            RuleFor(c => c.ModelName).MinimumLength(2);

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).NotNull();

            RuleFor(c => c.ModelName).NotEmpty();
            RuleFor(c => c.ModelName).NotNull();
            RuleFor(c => c.ModelName).MinimumLength(1);
            RuleFor(c => c.ModelName).MaximumLength(50);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).NotNull();
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.Description).MaximumLength(50);


            //RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.BrandId == 1);
            //RuleFor(c => c.ModelName).Must(StartWithA).WithMessage("Model isimleri A harfi ile başlamalı.");
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
