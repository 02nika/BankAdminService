namespace Entities.Exceptions;

public class CreateClientNotValidException : BadRequestException
{
    public CreateClientNotValidException(string message) : base($"CREATE_CLIENT_NOT_VALID_{message}")
    {
        
    }
}