using ECommerce.Entity;
using FluentValidation;

namespace ECommerce.Business.FluentValidation;

public class UserValidation:AbstractValidator<User>
{
    public UserValidation()
    {
        RuleFor(user => user.name).Length(2, 100).WithMessage(Messages.NameRequired);
        RuleFor(user => user.email).NotEmpty().WithMessage(Messages.EmailRequired);
        RuleFor(user => user.email).EmailAddress().WithMessage(Messages.InvalidEmail);
    }
    
}