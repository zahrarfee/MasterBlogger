using System;
using System.Collections.Generic;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;


namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get;private set; }
        public bool IsDeleted { get;private set; }
        public DateTime CreationDate { get;private set; }

        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {

        }
        public ArticleCategory(string title,IArticleCategoryValidationService articleCategoryValidationService)
        {
            articleCategoryValidationService.CheckThisRecordIsExists(title);
            GuardAgainstEmptyTitle(title);
            
            Title = title;
            IsDeleted = false;
            CreationDate=DateTime.Now;
            Articles = new List<Article>();
        }
        public void Edit(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
            IsDeleted = false;
            CreationDate = DateTime.Now;
        }

        public void GuardAgainstEmptyTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
        }

        public void Remove(int id)
        {
            IsDeleted = true;
        }

        public void Restore(int id)
        {
            IsDeleted = false;
        }
    }
}
