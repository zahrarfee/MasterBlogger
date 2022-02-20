using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MB.Application.contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleRepository:IArticleRepository
    {
        private readonly MasterBloggerContext _masterBloggerContext;

        public ArticleRepository(MasterBloggerContext masterBloggerContext)
        {
            _masterBloggerContext = masterBloggerContext;
        }

        public void Create(Article article)
        {
            _masterBloggerContext.Articles.Add(article);
            SaveChange();
        }

        public Article Get(int id)
        {
            return _masterBloggerContext.Articles.FirstOrDefault(x => x.Id == id);
        }

        public void SaveChange()
        {
            _masterBloggerContext.SaveChanges();
        }

        public bool Exists(string title)
        {
            return _masterBloggerContext.Articles.Any(x => x.Title==title);
        }



        public List<ArticleViewModel> GetList()
        {
            return _masterBloggerContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    IsDeleted = x.IsDeleted,
                    CreationDate = x.CreationDate.ToString()
                })
                .ToList();
        }

        public EditArticle GetEdited(int id)
        {
            return _masterBloggerContext.Articles.Select(x => new EditArticle
            {
                Id =x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Img = x.Img,
                Content = x.Content,
                ArticleCategoryId = x.ArticleCategoryId,
            }).FirstOrDefault(x=>x.Id==id);
        }
    }
}
