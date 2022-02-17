using System;



namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }
        public string Title { get;private set; }
        public bool IsDeleted { get;private set; }
        public DateTime CreationDate { get;private set; }

        public ArticleCategory(string title)
        {
            GuardAgainstEmptyTitle(title);
            
            Title = title;
            IsDeleted = false;
            CreationDate=DateTime.Now;
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
