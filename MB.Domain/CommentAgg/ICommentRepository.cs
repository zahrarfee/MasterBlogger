using System;
using System.Collections.Generic;
using System.Text;
using MB.Application.contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment comment);
        Comment Get(int id);
        List<CommentViewModel> CommentList();
        void SaveChange();

    }
}
