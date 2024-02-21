using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(i => i.Id).HasColumnName("Id");
            builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");
            builder.Property(i => i.UserName).HasColumnName("UserName");
            builder.Property(i => i.FirstName).HasColumnName("FirstName");
            builder.Property(i => i.LastName).HasColumnName("LastName");
            builder.Property(i => i.DateOfBirth).HasColumnName("DateOfBirth");
            builder.Property(i => i.Email).HasColumnName("Email");
            builder.Property(i => i.Password).HasColumnName("Password");
        }
    }
}
