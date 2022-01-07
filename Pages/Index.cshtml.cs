using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Razor_Blog.Mapping;
using Razor_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Blog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BlogContext _blog;

        public List<ArticleViewModel> mo { get; set; }
        public IndexModel(BlogContext blog)
        {
            _blog = blog;
        }
        public void OnGet()
        {

            mo = _blog.Articles.Where(x=>x.IsDeleted==false).Select(x => new ArticleViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                Body = x.Body,
                CreationDate = x.CreationDate.ToString(),
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Title = x.Title
            }).OrderByDescending(x=>x.Id).ToList();
            //ViewData["Message"] = "Hello Hosein";
        }

        public IActionResult OnGetDeleted(int id)
        {
          var  mo = _blog.Articles.First(x => x.Id == id);
            mo.IsDeleted = true;
            _blog.SaveChanges();
            return RedirectToPage("Index");
        }

        public IActionResult OnGetLoad()
        {
            return RedirectToPage("./Index");
            return Page();
        }
        public void OnPost(IFormFileCollection form)
        {

        }
    }
}
