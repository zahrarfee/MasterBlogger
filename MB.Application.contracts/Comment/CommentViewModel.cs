using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.contracts.Comment
{
    public class CommentViewModel
    {
        public int Id { get;   set; }
        public string Name { get;   set; }
        public string Email { get;   set; }
        public string Message { get;   set; }
        public string CreationDate { get;   set; }
        public int Status { get;   set; } //0=no status,1=accept,2=deny
       
        public string Article { get; set; }

    }
}
