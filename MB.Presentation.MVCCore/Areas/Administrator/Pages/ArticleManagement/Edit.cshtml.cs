using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.contracts.Article;
using MB.Application.contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleManagement
{
    public class EditModel : PageModel
    {
        public EditArticle Command;
        public SelectList ArticleCategorySelectList;
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        

        public void OnGet(int id)
        {
            Command = _articleApplication.GetEdited(id);
            ArticleCategorySelectList=new SelectList(_articleCategoryApplication.GetList(),"Id","Title");

        }

        public RedirectToPageResult OnPost(EditArticle command)
        {
            _articleApplication.Edit(command);
            return RedirectToPage("./List");
        }
  
    }
}
