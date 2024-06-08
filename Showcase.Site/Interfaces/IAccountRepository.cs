using Showcase.Models;

namespace Showcase.Interfaces;

public interface IAccountRepository
{
    IEnumerable<UserModel> GetAll();
    UserModel? GetById(int id);
    UserModel? GetByEmail(string email);
    void Insert(UserModel user);
    void Update(UserModel user);
    void Remove(UserModel user);
}