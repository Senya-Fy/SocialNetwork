using Microsoft.EntityFrameworkCore;
using SocialNetwork.Components;
using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Repository;

public class AccountRepository :  IAccountRepository
{
    private readonly AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Account>> GetAllAsync()
    {
        return await _context.Account.ToListAsync();
    }

    public async Task<Account?> GetByIdAsync(int id)
    {
        return await _context.Account.FindAsync(id);
    }

    public async Task AddAsync(Account account)
    {
        await _context.Account.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Account account)
    {
        _context.Account.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _context.Account.FindAsync(id);
        if (user != null)
        {
            _context.Account.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}