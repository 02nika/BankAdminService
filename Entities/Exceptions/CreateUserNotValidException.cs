namespace Entities.Exceptions;

public class CreateUserNotValidException : BadRequestException
{
    public CreateUserNotValidException(string message) : base($"CREATE_USER_NOT_VALID_{message}")
    {
        
    }
}