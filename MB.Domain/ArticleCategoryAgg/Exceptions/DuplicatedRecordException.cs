using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.ArticleCategoryAgg.Exceptions
{
    public class DuplicatedRecordException:Exception

    {
        public DuplicatedRecordException(string messege):base(messege)
        {
            
        }
    }
}
