using Showcase.Models;

namespace Showcase.Interfaces;

public interface IAccountRepository
{
    IEnumerable<UserModel> GetAll();
    UserModel? GetById(int id);
    UserModel? GetByEmail(string email);
    void Insert(UserModel model);
    void Update(UserModel model);
    void Remove(UserModel model);
}