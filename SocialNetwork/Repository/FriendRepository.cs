using Microsoft.EntityFrameworkCore;
using SocialNetwork.Components;
using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Repository;

public class FriendRepository : IFriendRepository
{
    private readonly AppDbContext _context;

    public FriendRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Friend>> GetAllAsync()
    {
        return await _context.Friend.ToListAsync();
    }

    public async Task<Friend?> GetByIdAsync(int accountId, int friendId)
    {
        return await _context.Friend.FindAsync(accountId, friendId);
    }
    
    public async Task<bool> AddAsync(Friend friend)
    {
        try
        {
            var accountExists = await _context.Account.AnyAsync(account => account.Id == friend.AccountId);
            
            var friendExists = await _context.Account.AnyAsync(account => account.Id == friend.FriendId);

            if (!accountExists || !friendExists)
                return false;
            
            var alreadyExists = await _context.Friend.AnyAsync(
                f => f.AccountId == friend.AccountId &&
                     f.FriendId == friend.FriendId);
            if (alreadyExists)
                return false;
            
            await _context.Friend.AddAsync(friend);
            await _context.SaveChangesAsync();
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    
    public async Task UpdateAsync(Friend friend)
    {
        _context.Friend.Update(friend);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int accountId, int friendId)
    {
        var user = await _context.Friend.FindAsync(accountId, friendId);
        if (user != null)
        {
            _context.Friend.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}