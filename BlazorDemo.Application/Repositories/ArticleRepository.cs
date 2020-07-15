using BlazorDemo.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorDemo.Application.Repositories
{
    public class ArticleRepository
    {
        private readonly ArticleDataContext articleDataContext;

        public ArticleRepository(ArticleDataContext articleDataContext)
        {
            this.articleDataContext = articleDataContext;
        }

        public Task<Article[]> GetArticlesAsync(Expression<Func<Article, bool>> expression = null)
        {
            if (expression == null) return articleDataContext.Articles.ToArrayAsync();
            return articleDataContext.Articles.Where(expression).ToArrayAsync();
        }

        public Task IncludeArticle(Article article)
        {
            articleDataContext.Articles.AddAsync(article);
            return articleDataContext.SaveChangesAsync();
        }

        public Task RemoveArticle(Article article)
        {
            articleDataContext.Articles.Remove(article);
            return articleDataContext.SaveChangesAsync();
        }

        public Task UpdateArticle(Article article)
        {
            articleDataContext.Articles.Attach(article);
            return articleDataContext.SaveChangesAsync();
        }

    }
}
