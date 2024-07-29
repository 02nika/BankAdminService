namespace Entities.Exceptions;

public class CreateClientNotValidException : BadRequestException
{
    public CreateClientNotValidException() : base("CREATE_CLIENT_NOT_VALID")
    {
        
    }
}