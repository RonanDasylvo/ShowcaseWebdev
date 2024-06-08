using Showcase.Models;

namespace Showcase.Interfaces;

public interface IAccountService
{
    IEnumerable<UserModel> GetAll();
    UserModel? GetById(int id);
    UserModel? GetByEmail(string email);
    void Save(UserModel user);
    void Remove(UserModel user);
}