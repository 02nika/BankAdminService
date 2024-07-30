namespace Entities.Exceptions;

public class PhoneNumberNotValidException : BadRequestException
{
    public PhoneNumberNotValidException() : base("PHONE_NUMBER_NOT_VALID") {}
}