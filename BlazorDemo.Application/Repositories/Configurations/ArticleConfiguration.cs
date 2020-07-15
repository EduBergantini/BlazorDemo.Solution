using BlazorDemo.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Application.Repositories.Configurations
{
    class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("TBL_ARTICLES");
            builder.HasKey(article => article.Id);
            builder.Property(article => article.Id).HasColumnName("ATCL_ID").ValueGeneratedOnAdd();
            builder.Property(article => article.Title).HasColumnName("ATCL_TITLE").HasMaxLength(60).IsRequired();
            builder.Property(article => article.Description).HasColumnName("ATCL_DESC").HasMaxLength(150).IsRequired();
            builder.Property(article => article.IsActive).HasColumnName("ATCL_ACTIVE").IsRequired().HasDefaultValue(false);
            builder.Property(article => article.RegisterDate).HasColumnName("ATCL_REGDATE").IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
