using System;
using System.Collections.Generic;
using System.Text;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public int Id { get; private set; }
        public  string Title { get; private set; }
        public  string ShortDescription  { get; private set; }
        public string Img { get; private set; }
        public  string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int ArticleCategoryId { get; private set; }
        public  ArticleCategory ArticleCategory { get; private set; }

        protected Article()
        {

        }
        public Article(string title, string shortDescription, string img, string content, int articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Img = img;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate=DateTime.Now;
        }
        public void Edit(string title, string shortDescription, string img, string content, int articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Img = img;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            


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
