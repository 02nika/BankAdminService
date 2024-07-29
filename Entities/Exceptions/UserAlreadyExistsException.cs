namespace Entities.Exceptions;

public class UserAlreadyExistsException : BadRequestException
{
    public UserAlreadyExistsException() : base("USER_ALREADY_EXISTS")
    {
        
    }
}