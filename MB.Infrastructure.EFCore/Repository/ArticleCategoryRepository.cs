using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MB.Application.contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository:IArticleCategoryRepository

    {
        private readonly MasterBloggerContext _masterBloggerContext;

        public ArticleCategoryRepository(MasterBloggerContext masterBloggerContext)
        {
            _masterBloggerContext = masterBloggerContext;
        }

        public void Create(ArticleCategory articleCategory)
        {
            _masterBloggerContext.ArticleCategories.Add(articleCategory);
            SaveChange();
            

        }

        public List<ArticleCategory> GetAll()
        {
            return _masterBloggerContext.ArticleCategories.OrderByDescending(x=>x.Id).ToList();
        }

        public void SaveChange()
        {
            _masterBloggerContext.SaveChanges();
        }

        public ArticleCategory Get(int id)
        {
            return _masterBloggerContext.ArticleCategories.FirstOrDefault(x => x.Id == id);
        }

        public EditArticleCategory GetDetails(int id)
        {
            return _masterBloggerContext.ArticleCategories.Select(x => new EditArticleCategory
                {
                    Id = x.Id,
                    Title = x.Title,
                })
                .FirstOrDefault(x => x.Id == id);
        }

        public bool Exists(string title)
        {
            return _masterBloggerContext.ArticleCategories.Any(x => x.Title == title);
        }

        public List<ArticleCategoryViewModel> GetList()
        {
            return _masterBloggerContext.ArticleCategories.Select(x => new ArticleCategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
    }
}
