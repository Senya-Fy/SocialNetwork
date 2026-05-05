using Microsoft.EntityFrameworkCore;
using SocialNetwork.Components;
using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Repository;

public class MessageRepository : IMessageRepository
{
    private readonly AppDbContext _context;

    public MessageRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Message>> GetAllAsync()
    {
        return await _context.Message.ToListAsync();
    }

    public async Task<Message?> GetByIdAsync(int id)
    {
        return await _context.Message.FindAsync(id);
    }

    public async Task AddAsync(Message message)
    {
        await _context.Message.AddAsync(message);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Message.FindAsync(id);
        if (user != null)
        {
            _context.Message.Remove(user);
            await _context.SaveChangesAsync();
        }
    }

}