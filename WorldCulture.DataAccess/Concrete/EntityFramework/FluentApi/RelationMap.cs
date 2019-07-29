using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class RelationMap : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> builder)
        {
            builder.Property(x => x.Date).HasColumnType("datetime2");

            builder.HasOne(x => x.FromAccount).WithMany(x => x.FromAccounts).HasForeignKey(x => x.FromAccountID);
            builder.HasOne(x => x.ToAccount).WithMany(x => x.ToAccounts).HasForeignKey(x => x.ToAccountID).IsRequired(false);
        }
    }
}
