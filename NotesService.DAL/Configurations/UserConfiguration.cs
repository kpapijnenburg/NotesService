using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.DAL.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(n => n.Notes)
                .WithOne(u => u.User);

            builder.HasData(new User()
            {
                Id = new Guid("845f9dec-2c0e-4e96-97ef-a0bbb48c3a25")
            });
        }
    }
}
