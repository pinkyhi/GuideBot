using GuideBot.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideBot.DAL.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Guide> Guides { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<GuidePage> GuidePages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<GuidePage>()
                .HasKey(gp => new { gp.PageId, gp.GuideId });
            modelBuilder.Entity<Guide>()
                .HasMany(g => g.GuidePages)
                .WithOne(gp => gp.Guide)
                .HasForeignKey(gp => gp.GuideId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Page>()
                .HasMany(p => p.GuidePages)
                .WithOne(gp => gp.Page)
                .HasForeignKey(gp => gp.PageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
