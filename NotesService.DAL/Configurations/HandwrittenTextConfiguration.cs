using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.DAL.Configurations
{
    class HandwrittenTextConfiguration : IEntityTypeConfiguration<HandwrittenText>
    {
        public void Configure(EntityTypeBuilder<HandwrittenText> builder)
        {
            builder
                .HasOne(h => h.Note)
                .WithOne(n => n.HandwrittenText)
                .HasForeignKey<HandwrittenText>(h => h.NoteId);

            builder
                .Property(h => h.State)
                .HasConversion(
                    s => s.ToString(),
                    s => (State)Enum.Parse(typeof(State), s)
                );

            builder.HasData(
                new HandwrittenText()
                {
                    Id = 1,
                    Image = null,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    State = State.Pending,
                    NoteId = 1
                }
            );
        }
    }
}
