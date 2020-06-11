using NotesService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace NotesService.DAL.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder
                .HasOne(n => n.User)
                .WithMany(u => u.Notes);

            builder.HasData(
                new Note()
                {
                    Id = 1,
                    Title = "Test Notitie",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    ImageData = new byte[0],
                    UserId = new Guid("845f9dec-2c0e-4e96-97ef-a0bbb48c3a25"),
                });
        }
    }
}
