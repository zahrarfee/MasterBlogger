using System.Collections.Generic;
using System.Linq;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _masterBloggerContext;

        public ArticleQuery(MasterBloggerContext masterBloggerContext)
        {
            _masterBloggerContext = masterBloggerContext;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _masterBloggerContext.Articles.Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    CreationDate = x.CreationDate.ToString(),
                    Img = x.Img,
                    ArticleCategory = x.ArticleCategory.Title,
                    CommentsCount = x.Comments.Count
                }).ToList();
        }

        public ArticleQueryView GetArticleQuery(int id)
        {
            return _masterBloggerContext.Articles.Include(x=>x.ArticleCategory).Select(x => new ArticleQueryView
            {

                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(),
                Img = x.Img,
                ArticleCategory = x.ArticleCategory.Title,
                Content = x.Content,
                CommentsCount = x.Comments.Count,
                Comments = MapComments(x.Comments.Where(x=>x.Status==Statuses.Confirmed))

            }).FirstOrDefault(x=>x.Id==id);
        }

        private static List<CommentsQueryView> MapComments(IEnumerable<Comment> comments)
        {
            //var result = new List<CommentsQueryView>();
            //foreach (var item in comments)
            //{
            //    result.Add(new CommentsQueryView
            //    {
            //        Name = item.Name,
            //        CreationDate = item.CreationDate.ToString(),
            //        Message = item.Message

            //    });
            //}

            //return result;
            return comments.Select(x => new CommentsQueryView
            {
                Name =x.Name,
                CreationDate = x.ToString(),
                Message = x.Message

            }).ToList();
        }
    }
}