using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.WebApi.Filter;

public class ValidationFilter : IActionFilter
{
    private readonly IServiceProvider _provider;

    public ValidationFilter(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        foreach (var arg in context.ActionArguments.Values)
        {
            if (arg == null) continue;

            var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());
            var validator = _provider.GetService(validatorType) as IValidator;

            if (validator == null) continue;

            var result = validator.Validate(new ValidationContext<object>(arg));
            if (!result.IsValid)
            {
                context.Result = new BadRequestObjectResult(result.Errors);
                return;
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}
