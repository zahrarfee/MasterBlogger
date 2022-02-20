using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleAgg.Services
{
    public  interface IArticleValidationServices
    {
        void CheckThisRecordIsExists(string title);

    }
}
