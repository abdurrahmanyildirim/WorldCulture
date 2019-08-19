using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Business.Abstract;
using WorldCulture.DataAccess.Abstract;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public Account GetAccountByID(int accountId)
        {
            return _accountDal.Get(x => x.AccountID == accountId);
        }

        public bool ChangePassword(Account account, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return false;
            }

            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            _accountDal.Update(account);

            return true;
        }

        public void Register(Account account, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            _accountDal.Add(account);

        }

        public Account Login(string email, string password)
        {
            var account = _accountDal.Get(x => x.Email == email);
            if (account == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return null;
            }

            return account;
        }

        public bool UserExists(string email)
        {
            if (_accountDal.Get(x => x.Email == email) != null)
            {
                return true;
            }
            return false;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
