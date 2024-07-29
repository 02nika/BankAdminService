using System.ComponentModel.DataAnnotations;

namespace Shared.Attributes;

public class ExactLengthAttribute : ValidationAttribute
{
    private readonly int _length;

    public ExactLengthAttribute(int length)
    {
        _length = length;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is string str && str.Length != _length)
            return new ValidationResult($"The field {validationContext.DisplayName} must be exactly {_length} characters long.");

        return ValidationResult.Success;
    }
}