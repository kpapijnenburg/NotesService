using Microsoft.EntityFrameworkCore;
using notes_service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.DAL
{
    class NotesContext : DbContext
    {
        private readonly string connectionString;

        public NotesContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        DbSet<Note> Notes { get; set; }
        DbSet<HandwrittenText> HandwrittenTexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
