﻿using Microsoft.EntityFrameworkCore;
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
                .WithOne(n => n.HandwrittenText);

            builder.HasData(
                new HandwrittenText()
                {
                    Id = 1,
                    Image = null,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    NoteId = 1
                }
            );
        }
    }
}
