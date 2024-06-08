using Microsoft.EntityFrameworkCore;
using Showcase.Data;
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

    public void Insert(UserModel user)
    {
        db.UserModels.Add(user);
        db.SaveChanges();
    }

    public void Update(UserModel user)
    {
        db.UserModels.Update(user);
        db.SaveChanges();
    }


    public void Remove(UserModel user)
    {
        db.UserModels.Remove(user);
        db.SaveChanges();
    }
}