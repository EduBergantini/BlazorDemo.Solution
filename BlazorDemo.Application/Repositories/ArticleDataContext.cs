using BlazorDemo.Application.Entities;
using BlazorDemo.Application.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Application.Repositories
{
    public class ArticleDataContext : DbContext
    {
        public ArticleDataContext(DbContextOptions options) 
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Paragraph> Paragraphs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ParagraphConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
