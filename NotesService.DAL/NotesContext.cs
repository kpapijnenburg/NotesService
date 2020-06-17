using Microsoft.EntityFrameworkCore;
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
        public NotesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
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
                if (entry.Entity is BaseEntity)
                {
                    ((BaseEntity)entry.Entity).UpdatedAt = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        ((BaseEntity)entry.Entity).CreatedAt = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
