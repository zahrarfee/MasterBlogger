using System.Data;
using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleAgg.Services
{
    public  class ArticleValidationServices : IArticleValidationServices
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleValidationServices(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void CheckThisRecordIsExists(string title)
        {
           
            if (_articleRepository.Exists(title))
            {
                throw new DuplicatedRecordException("یک رکورد با این نام قبلا ثبت شده است");
            }
        }
    }
}