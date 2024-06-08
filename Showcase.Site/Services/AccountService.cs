using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    public IEnumerable<UserModel> GetAll()
        => accountRepository.GetAll();

    public UserModel? GetById(int id)
        => accountRepository.GetById(id);

    public UserModel? GetByEmail(string email)
        => accountRepository.GetByEmail(email);

    public void Save(UserModel user)
    {
        if (GetById(user.Id) == null)
        {
            accountRepository.Insert(user);
            return;
        }
        accountRepository.Update(user);
    }

    public void Remove(UserModel user)
        => accountRepository.Remove(user);
}