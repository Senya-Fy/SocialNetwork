using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Model;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Controller;

[ApiController]
[Route("api/[controller]")]
public class FriendController : ControllerBase
{
    private readonly IFriendRepository _repository;

    public FriendController(IFriendRepository repository)
    {
        _repository = repository;
    }
    
    // GET: api/friend
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var friends = await _repository.GetAllAsync();
        return Ok(friends);
    }

    // GET: api/friend/5
    [HttpGet("{accountId}/{friendId}")]
    public async Task<IActionResult> GetById(int accountId, int friendId)
    {
        var friend = await _repository.GetByIdAsync(accountId, friendId);
        
        if (friend == null)
            return NotFound();

        return Ok(friend);
    }
    
    // POST: api/friend
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Friend friend)
    {
        friend.CreatedAt = DateTime.UtcNow;
        var result = await _repository.AddAsync(friend);
        Console.WriteLine($"AccountId={friend.AccountId}, FriendId={friend.FriendId}");
        if (!result)
            return Conflict(new
                {
                    message = "Unable to create friend"
                });
        
        return Ok(friend);
    }
    
    // PUT: api/friend/5
    [HttpPut("{accountId}/{friendId}")]
    public async Task<IActionResult> Update(int accountId, int friendId, [FromBody] Friend friend)
    {
        if (accountId != friend.AccountId || friendId != friend.FriendId)
            return BadRequest();

        await _repository.UpdateAsync(friend);
        return NoContent();
    }

    // DELETE: api/friend/5
    [HttpDelete("{accountId}/{friendId}")]
    public async Task<IActionResult> Delete(int accountId, int friendId)
    {
        await _repository.DeleteAsync(accountId, friendId);
        return NoContent();
    }
    
    /*// POST: api/friend
    [HttpPost]
    public async Task<IActionResult> Create(int accountId, int friendId, string status)
    {
        var friend = new Friend
        {
            FriendId = friendId,
            AccountId = accountId,
            Status = status,
            CreatedAt = DateTime.Now
        };
        await _repository.AddAsync(friend);
        return Ok(friend);
    }*/
}