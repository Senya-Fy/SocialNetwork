using SocialNetwork.Model;

namespace SocialNetwork.Repository.Interface;

public interface IFriendRepository
{
    Task<List<Friend>> GetAllAsync();
    
    Task<Friend?> GetByIdAsync(int accountId, int friendId);
    
    Task AddAsync(Friend friend);
    Task UpdateAsync(Friend friend);
    Task DeleteAsync(int accountId, int friendId);
}