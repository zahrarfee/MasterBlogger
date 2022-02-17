using System;
using System.Security.Authentication.ExtendedProtection;
using MB.Application;
using MB.Application.contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
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
            

            services.AddDbContext<MasterBloggerContext>(x =>
                x.UseSqlServer(connectionString));
        }
    }
}
