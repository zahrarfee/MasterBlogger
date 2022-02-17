using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class ListModel : PageModel
    {
        public List<ArticleCategoryViewModel> ArticleCategories { get; set; }
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public ListModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }
        public void OnGet()
        {
            ArticleCategories = _articleCategoryApplication.List();
        }

        public RedirectToPageResult OnGetReMove(int id)
        {
            _articleCategoryApplication.Remove(id);
            return RedirectToPage("./List");
        }
        public RedirectToPageResult OnGetActivate(int id)
        {
            _articleCategoryApplication.Restore(id);
            return RedirectToPage("./List");
        }
    }
}