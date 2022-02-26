using System.Collections.Generic;
using System.Linq;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _masterBloggerContext;

        public ArticleQuery(MasterBloggerContext masterBloggerContext)
        {
            _masterBloggerContext = masterBloggerContext;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _masterBloggerContext.Articles.Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate.ToString(),
                    Img = x.Img,
                    ArticleCategory = x.ArticleCategory.Title
                }).ToList();
        }

        public ArticleQueryView GetArticleQuery(int id)
        {
            return _masterBloggerContext.Articles.Include(x=>x.ArticleCategory).Select(x => new ArticleQueryView
            {

                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(),
                Img = x.Img,
                ArticleCategory = x.ArticleCategory.Title,
                Content = x.Content
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}