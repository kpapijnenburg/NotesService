using Microsoft.EntityFrameworkCore;
using NotesService.DAL.Configurations;
using NotesService.Domain.Models;


namespace NotesService.DAL
{
    public class NotesContext : DbContext
    {
        DbSet<Note> Notes { get; set; }
        DbSet<HandwrittenText> HandwrittenTexts { get; set; }

        public NotesContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new HandwrittenTextConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //// Override SaveChanges to always set CreatedAt and UpdatedAt fields when needed.
        //public override int SaveChanges()
        //{
        //    var entries = ChangeTracker
        //        .Entries();


        //    return base.SaveChanges();
        //}
    }
}
