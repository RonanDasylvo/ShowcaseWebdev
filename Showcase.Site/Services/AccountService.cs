using Microsoft.AspNetCore.Mvc;
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

    public void Save(UserModel model)
    {
        if (GetById(model.Id) == null)
        {
            accountRepository.Insert(model);
            return;
        }
        accountRepository.Update(model);
    }

    public void Create(UserModel model)
    {
        if (GetAll().All(x => x != model))
            accountRepository.Insert(model);
    }

    public void Remove(UserModel model)
        => accountRepository.Remove(model);
}