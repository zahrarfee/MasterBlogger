using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Create(CreateComment command)
        {
           var comment=new Comment(command.Name,command.Email,command.Message,command.ArticleId);
            _commentRepository.Create(comment);
            _commentRepository.SaveChange();
        }

        public void Edit(EditComment command)
        {
           var comment= _commentRepository.Get(command.Id);
           comment.Edit(command.Name,command.Email,command.Message,command.ArticleId);
           _commentRepository.SaveChange();
           
        }

        public List<CommentViewModel> CommentList()
        {
            return _commentRepository.CommentList();
        }

        public void Confirmed(int id)
        {
            var comment = _commentRepository.Get(id);
            comment.Confirmed(id);
            _commentRepository.SaveChange();
        }

        public void Canceled(int id)
        {
            var comment = _commentRepository.Get(id);
            comment.Canceled(id);
            _commentRepository.SaveChange();
        }
    }
}
