using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.ArticleCategory;

namespace MB.Domain.ArticleCategoryAgg
{
    public  interface IArticleCategoryRepository
    {
        void Create(ArticleCategory articleCategory);
        List<ArticleCategory> GetAll();

        void SaveChange();
        ArticleCategory Get(int id);
        EditArticleCategory GetDetails(int id);
        bool Exists(string title);
        List<ArticleCategoryViewModel> GetList();


    }
}
