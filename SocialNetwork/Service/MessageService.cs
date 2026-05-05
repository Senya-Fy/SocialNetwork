using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Service;

public class MessageService
{
    private readonly IMessageRepository _repository;

    public MessageService(IMessageRepository messageRepository)
    {
        _repository = messageRepository;
    }

    public async Task CreateMessage(int id, int senderId,
        int receiverId, string content, DateTime CreatedAt)
    {
        await _repository.AddAsync(new Message
        {
            Id = id,
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = content,
            CreatedAt = CreatedAt
        });
    }
}