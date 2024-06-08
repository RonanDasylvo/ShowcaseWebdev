using Microsoft.EntityFrameworkCore;
using Showcase.Data;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Repositories;

public class AccountRepository(ShowcaseDbContext db) : IAccountRepository
{
    public async Task<IEnumerable<UserModel>> GetAll()
        => await db.UserModels.ToListAsync();

    public async Task<UserModel?> GetById(int id)
        => await db.UserModels.SingleOrDefaultAsync(x => x.Id == id);

    public void Insert(UserModel user)
        => db.UserModels.Add(user);

    public void Update(UserModel user)
        => db.UserModels.Update(user);
    
    public void Remove(UserModel user)
        => db.UserModels.Remove(user);
}