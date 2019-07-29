using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.CityName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.CityPhotoPath).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Population).IsRequired();
        }
    }
}
