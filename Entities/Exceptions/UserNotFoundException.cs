namespace Entities.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base("USER_NOT_FOUND")
    {
        
    }
}