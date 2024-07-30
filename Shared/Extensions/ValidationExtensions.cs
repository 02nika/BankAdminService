using System.ComponentModel.DataAnnotations;

namespace Shared.Extensions;

public static class ValidationExtensions
{
    public static bool IsValid<T>(this T item, out string errorMessage)
    {
        errorMessage = null;

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(item);
        var isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);

        if (isValid) return true;
        
        errorMessage = string.Join("; ", validationResults.Select(vr => vr.ErrorMessage));
        return false;
    }
}