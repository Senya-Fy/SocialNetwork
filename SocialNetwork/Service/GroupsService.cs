using SocialNetwork.Model;
using SocialNetwork.Repository;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Service;

public class GroupsService
{
    private readonly IGroupsRepository _repo;

    public GroupsService(IGroupsRepository repo)
    {
        _repo = repo;
    }

    public async Task CreateAccount(int id, string title, 
        int ownerId, DateTime createdAt)
    {
        await _repo.AddAsync(new Groups
        {
            Id = id,
            Title = title,
            OwnerId = ownerId,
            CreatedAt = createdAt
        });
    }
}