using Showcase.Models;

namespace Showcase.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<UserModel>> GetAll();
    Task<UserModel?> GetById(int id);
    void Save(UserModel user);
    void Remove(UserModel user);
}