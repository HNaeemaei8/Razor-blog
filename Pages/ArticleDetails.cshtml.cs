using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Blog.Mapping;
using Razor_Blog.Models;

namespace Razor_Blog.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleViewModel  Article { get; set; }
        private readonly BlogContext _blog;
        public ArticleDetailsModel(BlogContext blog)
        {
            _blog = blog;
        }
        public void OnGet(int id)
        {
            Article = _blog.Articles.Select(x => new ArticleViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Body = x.Body,
                CreationDate = x.CreationDate.ToString(),
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title
            }).FirstOrDefault(X => X.Id == id);
        }
    }
}
