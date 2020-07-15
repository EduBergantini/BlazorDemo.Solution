using BlazorDemo.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Application.Repositories.Configurations
{
    class ParagraphConfiguration : IEntityTypeConfiguration<Paragraph>
    {
        public void Configure(EntityTypeBuilder<Paragraph> builder)
        {
            builder.ToTable("TBL_PARAGRAPHS");
            builder.HasKey(paragraph => paragraph.Id);
            builder.Property(paragraph => paragraph.Id).HasColumnName("PRPH_ID").ValueGeneratedOnAdd();
            builder.Property(paragraph => paragraph.ArticleId).HasColumnName("ATCL_ID").IsRequired();
            builder.Property(paragraph => paragraph.Content).HasColumnName("PRPH_CONTENT").HasMaxLength(60).IsRequired();
            builder.Property(paragraph => paragraph.ImageUrl).HasColumnName("PRPH_IMGURL").HasMaxLength(150).IsRequired();
            builder.Property(paragraph => paragraph.IsActive).HasColumnName("PRPH_ACTIVE").IsRequired().HasDefaultValue(false);
            builder.Property(paragraph => paragraph.RegisterDate).HasColumnName("PRPH_REGDATE").IsRequired().HasDefaultValue(DateTime.Now);

            builder.HasOne<Article>(paragraph => paragraph.Article)
                .WithMany(article => article.Paragraphs)
                .HasConstraintName("FK_ATCL_PRPHS");
                
        }
    }
}
