using System;
using System.Security.Authentication.ExtendedProtection;
using MB.Application;
using MB.Application.contracts.Article;
using MB.Application.contracts.ArticleCategory;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleAgg.Services;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
using MB.Infrastructure.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class BootStrapper
    {
        public static void Config(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleApplication,ArticleApplication>();

            services.AddTransient<IArticleQuery, ArticleQuery>();

            services.AddTransient<IArticleValidationServices, ArticleValidationServices>();
            services.AddTransient<IArticleCategoryValidationService, ArticleCategoryValidationService>();


            services.AddDbContext<MasterBloggerContext>(x =>
                x.UseSqlServer(connectionString));
        }
    }
}
