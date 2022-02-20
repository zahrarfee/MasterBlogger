using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title,command.ShortDescription,command.Img,command.Content,command.ArticleCategoryId);
            _articleRepository.Create(article);
            _articleRepository.SaveChange();
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Img, command.Content,command.ArticleCategoryId);
            _articleRepository.SaveChange();
        }

        public List<ArticleViewModel> GetList()
        {


            return _articleRepository.GetList();

        }

        public void Remove(int id)
        {
            var article = _articleRepository.Get(id);
            article.Remove(id);
            _articleRepository.SaveChange();

        }

        public void Restore(int id)
        {
            var article = _articleRepository.Get(id);
            article.Restore(id);
            _articleRepository.SaveChange();
        }

        public EditArticle GetEdited(int id)
        {
            return _articleRepository.GetEdited(id);
        }
    }
}
