
using Domain.Models.Entities;
using Infra.EntityConfiguration.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Infra.EntityConfiguration
{
    public class ApplicationDbContext : DbContext
    {

        public static bool isCreated = false;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public ApplicationDbContext()
        {

            if (!File.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}\ecad.db"))
            {
                isCreated = true;
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {            
            optionbuilder.UseSqlite($@"Data Source={$@"{AppDomain.CurrentDomain.BaseDirectory}\ecad.db"}");
        }

        public DbSet<Music> Music { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MusicMap());
            modelBuilder.ApplyConfiguration(new GenderMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());

            //Music
            modelBuilder.Entity<Music>()
               .HasOne(e => e.Gender)
               .WithMany(c => c.Musics)
               .HasForeignKey(p => p.CodGender);

            modelBuilder.Entity<Music>()
               .HasOne(e => e.Author)
               .WithMany(c => c.Musics)
               .HasForeignKey(p => p.CodAuthor);

            //Author
            modelBuilder.Entity<Author>()
                .HasMany(c => c.Musics)
                .WithOne(e => e.Author);
       

            modelBuilder.Entity<Author>()
              .HasOne(c => c.Category)
              .WithMany(e => e.Authors)
              .HasForeignKey(p => p.CodCategory);

            //Gender
            modelBuilder.Entity<Gender>()
                .HasMany(c => c.Musics)
                .WithOne(e => e.Gender);

            //Category
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Authors)
                .WithOne(e => e.Category);

        }
    }
}