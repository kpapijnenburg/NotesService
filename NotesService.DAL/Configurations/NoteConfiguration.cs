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
            builder.HasData(new Note() { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, ImageData = new byte[0] });
        }
    }
}
