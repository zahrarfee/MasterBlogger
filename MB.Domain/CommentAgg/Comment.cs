using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public DateTime CreationDate { get; private set; }
        public int Status { get; private set; } //0=no status,1=accept,2=deny
        public int ArticleId { get; private set; }
        public Article Article { get; private set; }


        protected Comment()
        {

        }
        public Comment(string name, string email, string message,int articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            CreationDate = DateTime.Now;
            Status =Statuses.New;
        }

        public void Confirmed(int id)
        {
            Status = Statuses.Confirmed;
        }
        public void Canceled(int id)
        {
            Status = Statuses.Canceled;
        }

        public void Edit(string name, string email, string message, int articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;

        }
    }
}
