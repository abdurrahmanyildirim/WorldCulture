using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WorldCulture.Entities.Concrete;

namespace WorldCulture.DataAccess.Concrete.EntityFramework.FluentApi
{
    public class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.ReviewContent).IsRequired();
            builder.Property(x => x.ReviewDate).HasColumnType("datetime2");
            
        }
    }
}
