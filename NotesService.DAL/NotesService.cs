using Microsoft.EntityFrameworkCore;
using NotesService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesService.DAL
{
    class NotesService : DbContext
    {
        private readonly string connectionString;

        public NotesService(string connectionString)
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
