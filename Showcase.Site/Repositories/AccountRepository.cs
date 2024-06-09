using Microsoft.EntityFrameworkCore;
using Showcase.Contexts;
using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Repositories;

public class AccountRepository(ShowcaseDbContext db) : IAccountRepository
{
    public IEnumerable<UserModel> GetAll()
        => db.UserModels.ToList();

    public UserModel? GetById(int id)
        => db.UserModels.SingleOrDefault(x => x.Id == id);

    public UserModel? GetByEmail(string email)
        => db.UserModels.SingleOrDefault(x => x.Email == email);

    public void Insert(UserModel model)
    {
        db.UserModels.Add(model);
        db.SaveChanges();
    }

    public void Update(UserModel model)
    {
        db.UserModels.Update(model);
        db.SaveChanges();
    }
    
    public void Remove(UserModel model)
    {
        db.UserModels.Remove(model);
        db.SaveChanges();
    }
}