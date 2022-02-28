using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.contracts.Comment
{
    public class CreateComment
    {
    
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public int ArticleId { get; set; }
       

    }
}
