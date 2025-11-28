using ECommerce.Entity;
using FluentValidation;

namespace ECommerce.Business.FluentValidation.Products;

public class ProductCreateDtoValidation:AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidation()
    {
        RuleFor(product =>  product.Name).NotEmpty().NotNull().WithMessage(Messages.ProductNameRequired);
        RuleFor(product => product.Price).NotEmpty().NotNull().WithMessage(Messages.ProductPriceRequired);
        RuleFor(product => product.Stock).NotEmpty().NotNull().WithMessage(Messages.ProductStockRequired);
        RuleFor(product => product.Price).GreaterThan(0).WithMessage(Messages.ProductPriceMustBeGreaterThanZero);
        RuleFor(product => product.Stock).GreaterThan(0).WithMessage(Messages.ProductStockMustBeGreaterThanZero);
    }
}