using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.FirstName).MaximumLength(15);

            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.LastName).MaximumLength(15);

            //RuleFor(u => u.Password).NotEmpty();
            //RuleFor(u => u.Password).NotNull();
            //RuleFor(u => u.Password).MinimumLength(8);
            //RuleFor(u => u.Password).MaximumLength(20);

            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Email).EmailAddress();
        }
    }
}
