using System;
using System.Collections.Generic;
using System.Text;

namespace WorldCulture.Entities.Concrete
{
    public class Account
    {
        public Account()
        {
            Despatches = new List<Despatch>();
            FromAccounts = new List<Relation>();
            ToAccounts = new List<Relation>();
        }

        public int AccountID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonelInfo { get; set; }
        public string ProfilePhotoPath { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime MemberDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Role Role { get; set; }
        public virtual List<Despatch> Despatches { get; set; }
        public virtual List<Relation> FromAccounts { get; set; }
        public virtual List<Relation> ToAccounts { get; set; }
    }
}
