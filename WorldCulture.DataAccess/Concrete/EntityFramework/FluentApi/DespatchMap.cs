using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class DespatchMap : IEntityTypeConfiguration<Despatch>
    {
        public void Configure(EntityTypeBuilder<Despatch> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnType("datetime2");
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.DespatchPhotoPath).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(30).IsRequired();
        }
    }
}
