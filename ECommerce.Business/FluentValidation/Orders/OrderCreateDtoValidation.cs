using ECommerce.Entity;
using FluentValidation;

namespace ECommerce.Business.FluentValidation.Orders;

public class OrderCreateDtoValidation:AbstractValidator<OrderCreateDto>
{
    public OrderCreateDtoValidation()
    {
        RuleFor(order => order.UserId).NotEmpty().NotNull().GreaterThan(0).WithMessage(Messages.UserIDCantEmpty);
        RuleFor(order => order.ProductId).NotEmpty().NotNull().GreaterThan(0).WithMessage(Messages.ProductIDCantEmpty);
        RuleFor(order => order.Quantity).NotEmpty().NotNull().WithMessage(Messages.ProductQuantityCantEmpty);

    }
}