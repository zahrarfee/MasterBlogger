using System;
using System.Collections.Generic;
using System.Globalization;
using MB.Application.contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;


namespace MB.Application
{
    public class ArticleCategoryApplication:IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidationService _articleCategoryValidationService;
        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidationService articleCategoryValidationService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidationService = articleCategoryValidationService;
        }

        public void Create(CreateArticleCategory command)
        {
            var articleCategory=new  ArticleCategory(command.Title,_articleCategoryValidationService);
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChange();
        }

        public void Edit(EditArticleCategory command)
        {
            var articleCategory=_articleCategoryRepository.Get(command.Id);
            articleCategory.Edit(command.Title);
            _articleCategoryRepository.SaveChange();

        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            var result=new List<ArticleCategoryViewModel>();

            foreach (var articleCategory in articleCategories)
            {
                result.Add(new ArticleCategoryViewModel
                {
                    Id = articleCategory.Id,
                    Title = articleCategory.Title,
                    IsDeleted = articleCategory.IsDeleted,
                    CreationDate = articleCategory.CreationDate.ToString()
                });
            }

            return result;

        }

        public EditArticleCategory GetDetails(int id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public void Remove(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            if (articleCategory == null)
                return;
            articleCategory.Remove(id);
            _articleCategoryRepository.SaveChange();
        }

        public void Restore(int id)
        {
            var articleCategory = _articleCategoryRepository.Get(id);
            if(articleCategory==null)
                return;
            articleCategory.Restore(id);
            _articleCategoryRepository.SaveChange();
        }

        public List<ArticleCategoryViewModel> GetList()
        {
            return _articleCategoryRepository.GetList();
        }
    }
}
