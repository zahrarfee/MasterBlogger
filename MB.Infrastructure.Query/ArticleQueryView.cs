﻿ using System;

namespace MB.Infrastructure.Query
{
    public class ArticleQueryView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string CreationDate { get; set; }
        public string ArticleCategory { get; set; }
        public  string Img { get; set; }
        public string Content { get; set; }
    }
}
