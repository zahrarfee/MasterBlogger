using System;
using System.Data;
using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services
{
     public class ArticleCategoryValidationService : IArticleCategoryValidationService
     {
         private readonly IArticleCategoryRepository _articleCategoryRepository;

         public ArticleCategoryValidationService(IArticleCategoryRepository articleCategoryRepository)
         {
             _articleCategoryRepository = articleCategoryRepository;
         }

         public void CheckThisRecordIsExists(string title)
        {
            if (_articleCategoryRepository.Exists(title))
            {
                throw new DuplicatedRecordException("یک رکورد با این نام قبلا ثبت شده است");
            }
        }
    }
}