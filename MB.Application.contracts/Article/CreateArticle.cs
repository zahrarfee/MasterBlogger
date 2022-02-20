using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Img { get; set; }
        public string Content { get; set; }
        public int ArticleCategoryId { get; set; }
    }
}
