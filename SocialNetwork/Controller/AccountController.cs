using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Model;
using SocialNetwork.Repository;
using SocialNetwork.Repository.Interface;

namespace SocialNetwork.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _repository;

    public AccountController(IAccountRepository repository)
    {
        _repository = repository;
    }

    // GET: api/account
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _repository.GetAllAsync();
        return Ok(accounts);
    }

    // GET: api/account/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await _repository.GetByIdAsync(id);

        if (account == null)
            return NotFound();

        return Ok(account);
    }

    // POST: api/account
    [HttpPost]
    public async Task<IActionResult> Create(Account account)
    {
        await _repository.AddAsync(account);
        return Ok(account);
    }

    // PUT: api/account/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Account account)
    {
        if (id != account.Id)
            return BadRequest();

        await _repository.UpdateAsync(account);
        return NoContent();
    }

    // DELETE: api/account/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}