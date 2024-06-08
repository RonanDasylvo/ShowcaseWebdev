using Showcase.Interfaces;
using Showcase.Models;

namespace Showcase.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    public async Task<IEnumerable<UserModel>> GetAll()
        => await accountRepository.GetAll();

    public async Task<UserModel?> GetById(int id)
        => await accountRepository.GetById(id);

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