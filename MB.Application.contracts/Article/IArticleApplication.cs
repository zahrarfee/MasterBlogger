using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.contracts.Article
{
    public interface IArticleApplication
    {
        void Create(CreateArticle command);
        void Edit(EditArticle command);
        List<ArticleViewModel> GetList();
        void Remove(int Id);
        void Restore(int Id);
        EditArticle GetEdited(int id);

    }
}
