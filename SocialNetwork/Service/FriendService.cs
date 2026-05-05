using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Service;

public class FriendService
{
    private readonly IFriendRepository _friendRepository;

    public FriendService(IFriendRepository friendRepository)
    {
        _friendRepository = friendRepository;
    }

    public async Task CreateFriend(int accountId, int friendId,
        string status, DateTime createdAt)
    {
        await _friendRepository.AddAsync(new Friend
        {
            AccountId = accountId,
            FriendId = friendId,
            Status = status,
            CreatedAt = createdAt
        });
    }
}