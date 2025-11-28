
using ECommerce.Core.Response;
using FluentValidation;

namespace ECommerce.Core;

public static class Utility
{
    public static ValidatorResponse Validator<T>(T entity, AbstractValidator<T> validator) where T : class,new()
    {
        ValidatorResponse returned = new ValidatorResponse();
        var valid = validator.Validate(entity);
        
        returned.IsValid = valid.IsValid;
        if (!valid.IsValid)
        {
            returned.messages = valid.Errors;
        }
        
        return returned;
    }
    
}

