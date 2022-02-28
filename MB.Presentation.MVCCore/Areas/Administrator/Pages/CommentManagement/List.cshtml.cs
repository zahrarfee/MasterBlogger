using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.CommentManagement
{
    public class ListModel : PageModel
    {
        public List<CommentViewModel> Comments;
        private readonly ICommentApplication _commentApplication;

        public ListModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet()
        {
            Comments = _commentApplication.CommentList();
        }

        public RedirectToPageResult OnGetConfirmed(int id)
        {
            _commentApplication.Confirmed(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnGetCanceled(int id)
        {
            _commentApplication.Canceled(id);
            return RedirectToPage("./List");
        }
    }
}
