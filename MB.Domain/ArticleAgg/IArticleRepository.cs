using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        void Create(Article article);
        Article Get(int id);
        void SaveChange();
        bool Exists(string title);
    

        List<ArticleViewModel> GetList();

        EditArticle GetEdited(int id);

    }
}
