using Showcase.Models;

namespace Showcase.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<UserModel>> GetAll();
    Task<UserModel?> GetById(int id);
    void Insert(UserModel user);
    void Update(UserModel user);
    void Remove(UserModel user);
}