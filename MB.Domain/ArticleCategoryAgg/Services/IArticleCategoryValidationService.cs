using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidationService
    {
        void CheckThisRecordIsExists(string title);
    }
}
