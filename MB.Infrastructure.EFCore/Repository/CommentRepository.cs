using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MB.Application.contracts.Comment;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBloggerContext _context;

        public CommentRepository(MasterBloggerContext context)
        {
            _context = context;
        }






        public void Create(Comment comment)
        {
            _context.Comments.Add(comment);
            SaveChange();
        }

        public Comment Get(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.Id == id);
        }

        public List<CommentViewModel> CommentList()
        {
            return _context.Comments.Include(x => x.Article).Select(x => new CommentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Message = x.Message,
                Email = x.Email,
                CreationDate = x.CreationDate.ToString(),
                Status = x.Status,
                Article = x.Article.Title,
            }).ToList();
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
