using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        private readonly IArticleApplication _articleApplication;

        public ListModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetList();
        }
        public RedirectToPageResult OnGetRemove(int id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _articleApplication.Restore(id);
            return RedirectToPage("./List");
        }
    }
}
