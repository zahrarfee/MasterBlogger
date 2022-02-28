using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.contracts.Comment
{
    public interface ICommentApplication
    {
        void Create(CreateComment command);
        void Edit(EditComment command);
        List<CommentViewModel> CommentList();
        void Confirmed(int id);
        void Canceled(int id);
    }
}
