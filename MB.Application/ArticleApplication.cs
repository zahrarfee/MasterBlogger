using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;

namespace MB.Application
{
    public class ArticleApplication:IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleValidationServices _articleValidationServices;

        public ArticleApplication(IArticleRepository articleRepository, IArticleValidationServices articleValidationServices)
        {
            _articleRepository = articleRepository;
            _articleValidationServices = articleValidationServices;
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title,command.ShortDescription,command.Img,command.Content,command.ArticleCategoryId,_articleValidationServices);
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
