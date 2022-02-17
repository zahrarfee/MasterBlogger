using System;
using System.Collections.Generic;

namespace MB.Application.contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        void Create(CreateArticleCategory command);
        void Edit(EditArticleCategory command);
        List<ArticleCategoryViewModel> List();
        EditArticleCategory GetDetails(int id);
        void Remove(int id);
        void Restore(int id);
    }
}
