using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlazorDemo.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Application.Repositories
{
    public class ParagraphRepository
    {
        private readonly ArticleDataContext articleDataContext;

        public ParagraphRepository(ArticleDataContext articleDataContext)
        {
            this.articleDataContext = articleDataContext;
        }

        public Task<Paragraph[]> GetParagraphsAsync(Expression<Func<Paragraph, bool>> expression = null)
        {
            if (expression == null) return articleDataContext.Paragraphs.ToArrayAsync();
            return articleDataContext.Paragraphs.Where(expression).ToArrayAsync();
        }

        public Task AddParagraph(Paragraph paragraph)
        {
            articleDataContext.Paragraphs.Add(paragraph);
            return articleDataContext.SaveChangesAsync();
        }

        public Task RemoveParagraph(Paragraph paragraph)
        {
            articleDataContext.Paragraphs.Remove(paragraph);
            return articleDataContext.SaveChangesAsync();
        }

        public Task UpdateParagraph(Paragraph paragraph)
        {
            articleDataContext.Paragraphs.Attach(paragraph);
            return articleDataContext.SaveChangesAsync();
        }
    }
}
