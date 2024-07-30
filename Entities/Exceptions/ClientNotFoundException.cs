namespace Entities.Exceptions;

public class ClientNotFoundException : NotFoundException
{
    public ClientNotFoundException() : base("CLIENT_NOT_FOUND") {}
}