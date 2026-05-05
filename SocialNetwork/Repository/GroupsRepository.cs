using Microsoft.EntityFrameworkCore;
using SocialNetwork.Components;
using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Repository;

public class GroupsRepository : IGroupsRepository
{
    private readonly AppDbContext _context;

    public GroupsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Groups>> GetAllAsync()
    {
        return await _context.Groups.ToListAsync();
    }

    public async Task<Groups?> GetByIdAsync(int id)
    {
        return await _context.Groups.FindAsync(id);
    }
    
    public async Task AddAsync(Groups groups)
    {
        await _context.Groups.AddAsync(groups);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Groups.FindAsync(id);
        if (user != null)
        {
            _context.Groups.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}