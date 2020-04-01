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
                .HasOne(n => n.HandwrittenText)
                .WithOne(h => h.Note)
                .HasForeignKey<HandwrittenText>(h => h.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasData(
                    new Note()
                    {
                        Id = 1,
                        Title = "Test Title",
                        Content = "Test Content",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        HandwrittenTextId = 1
                    }
                );
        }
    }
}
