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
    public class CreateModel : PageModel
    {
        public SelectList ArticleCategorySelectList;
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            ArticleCategorySelectList = new SelectList(_articleCategoryApplication.GetList(),"Id" ,"Title");
        }

        public RedirectToPageResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./List");
        }
    }
}
