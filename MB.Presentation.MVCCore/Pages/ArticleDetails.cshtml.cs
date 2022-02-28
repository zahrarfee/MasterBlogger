

using System.Collections.Generic;
using System.Linq;
using MB.Application.contracts.Comment;
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleQueryView articleQueryView;
        
        private readonly IArticleQuery _articleQuery;
        private readonly ICommentApplication _commentApplication;


        public ArticleDetailsModel(IArticleQuery articleQuery, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _commentApplication = commentApplication;
        }


        public void OnGet(int id)
        {
            articleQueryView = _articleQuery.GetArticleQuery(id);
           
        }

        public RedirectToPageResult OnPost(CreateComment command)
        {
            _commentApplication.Create(command);
            return RedirectToPage("./ArticleDetails" , new {id=command.ArticleId});
        }
       
    }
}