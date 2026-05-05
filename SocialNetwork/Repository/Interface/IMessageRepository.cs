using SocialNetwork.Model;

namespace SocialNetwork.Repository.Interface;

public interface IMessageRepository
{
    Task<List<Message>> GetAllAsync();
    Task<Message> GetByIdAsync(int id);
    Task AddAsync(Message message);
    Task DeleteAsync(int id);
}