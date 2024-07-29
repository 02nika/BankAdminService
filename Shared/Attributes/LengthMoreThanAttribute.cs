using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Shared.Attributes;

public class LengthMoreThanAttribute : ValidationAttribute
{
    private readonly int _length;

    public LengthMoreThanAttribute(int length)
    {
        _length = length;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is not IEnumerable enumerable) return new ValidationResult("The field must be exactly collection.");

        var count = enumerable.Cast<object>().Count();

        if (count == 0)
            return new ValidationResult(
                $"The field {validationContext.DisplayName} must be exactly {_length} characters long.");

        return ValidationResult.Success;
    }
}