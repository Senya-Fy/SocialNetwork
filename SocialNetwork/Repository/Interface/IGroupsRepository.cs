using SocialNetwork.Model;

namespace SocialNetwork.Repository.Interface;

public interface IGroupsRepository
{
    Task<List<Groups>> GetAllAsync();
    
    Task<Groups?> GetByIdAsync(int id);
    
    Task AddAsync(Groups groups);

    Task DeleteAsync(int id);
}