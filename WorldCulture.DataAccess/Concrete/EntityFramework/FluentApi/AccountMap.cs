using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder )
        {
            builder.Property(x => x.FirstName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(x => x.PersonelInfo).HasColumnType("nvarchar").HasMaxLength(120).IsRequired();
            builder.Property(x => x.UserName).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasColumnType("nvarchar").HasMaxLength(60);
            builder.Property(x => x.BirthDate).HasColumnType("datetime2");
            builder.Property(x => x.MemberDate).HasColumnType("datetime2");
        }
    }
}
