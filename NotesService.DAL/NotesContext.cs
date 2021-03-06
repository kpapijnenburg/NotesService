﻿using Microsoft.EntityFrameworkCore;
using NotesService.DAL.Configurations;
using NotesService.Domain;
using NotesService.Domain.Models;
using System;
using System.Linq;

namespace NotesService.DAL
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<HandwrittenText> HandwrittenTexts { get; set; }

        public NotesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new HandwrittenTextConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        // Override SaveChanges to always set CreatedAt and UpdatedAt fields when needed.
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).UpdatedAt = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.Now;

                    // If handwritten text is added the State should be set to Pending.
                    if (entry.Entity.GetType() == typeof(HandwrittenText))
                    {
                        ((HandwrittenText)entry.Entity).State = State.Pending;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
