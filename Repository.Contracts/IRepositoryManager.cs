namespace Repository.Contracts;

public interface IRepositoryManager
{
    IUserRepository UserRepository { get; }
    IClientRepository ClientRepository { get; }
    IClientSearchSuggestionsRepository ClientSearchSuggestions { get; }
    Task SaveAsync();
}