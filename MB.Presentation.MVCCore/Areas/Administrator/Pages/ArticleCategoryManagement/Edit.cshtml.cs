using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        public EditArticleCategory Command;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(int id)
        {
            Command = _articleCategoryApplication.GetDetails(id);

        }

        public RedirectToPageResult OnPost(EditArticleCategory command)
        {
            _articleCategoryApplication.Edit(command);
           return RedirectToPage("./List");
        }
    }
}
