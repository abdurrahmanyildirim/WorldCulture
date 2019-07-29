using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class FamousPlaceMap : IEntityTypeConfiguration<FamousPlace>
    {
        public void Configure(EntityTypeBuilder<FamousPlace> builder)
        {
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.PhotoPath).IsRequired();
            builder.Property(x => x.PlaceName).HasMaxLength(50).IsRequired();
        }
    }
}
