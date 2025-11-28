using AutoMapper;
using ECommerce.Entity;
using FluentValidation;

namespace ECommerce.Business.FluentValidation;

public class UserCreateDtoValidation:AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidation()
    {
        RuleFor(user => user.email).EmailAddress().NotEmpty().WithMessage(Messages.EmailRequired);
        RuleFor(user => user.name).Length(3, 100).WithMessage(Messages.NameRequired);
    }
}