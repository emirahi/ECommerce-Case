using FluentValidation.Results;

namespace ECommerce.Core.Response;

public class ValidatorResponse
{
    public bool IsValid { get; set; }
    public List<ValidationFailure> messages { get; set; } = new List<ValidationFailure>();
}