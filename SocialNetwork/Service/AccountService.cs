using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Service;

public class AccountService
{
    private readonly IAccountRepository _repo;

    public AccountService(IAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task CreateAccount(string userName, string password, string email)
    {
        await _repo.AddAsync(new Account()
        {
            UserName = userName,
            Password = password, Email = email
        });
    }
}