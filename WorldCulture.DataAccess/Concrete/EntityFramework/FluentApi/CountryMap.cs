using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Capital).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CountryName).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Currency).HasMaxLength(6).IsRequired();
            builder.Property(x => x.EthnicIdentity).HasMaxLength(20).IsRequired();
            builder.Property(x => x.FlagPhotoPath).IsRequired();
            builder.Property(x => x.FoundedDate).HasColumnType("datetime2");
            builder.Property(x => x.Language).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Population).HasMaxLength(13).IsRequired();
            builder.Property(x => x.President).HasMaxLength(80).IsRequired();
            builder.Property(x => x.SummaryInfo).IsRequired();
        }
    }
}
