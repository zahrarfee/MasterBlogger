﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
        ArticleQueryView GetArticleQuery(int id);
    }
}
