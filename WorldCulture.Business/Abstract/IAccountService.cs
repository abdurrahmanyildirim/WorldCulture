﻿using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Abstract
{
    public interface IAccountService
    {
        void Register(Account account, string password);
        Account Login(string email, string password);
        bool UserExists(string email);
        bool ChangePassword(Account account, string password);
        Account GetAccountByID(int accountId);
        void Update(Account account);
        List<Account> GetHasMostFollowerAccounts();
        List<Account> GetAccountsBySearchKey(string key);
    }
}
