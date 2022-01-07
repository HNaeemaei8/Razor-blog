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
    public class CreateArticleModel : PageModel
    {
        private readonly BlogContext _blog;

        [TempData]
        public string   ErrorMessage { get; set; }

        //[TempData]
        //public string SuccessMessage { get; set; }
        public CreateArticle createArticle  { get; set; }
        public CreateArticleModel(BlogContext blog)
        {
            _blog = blog;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost( CreateArticle create)
        {
            if (ModelState.IsValid)
            {
                var article = new Article(create.Title, create.Picture, create.PictureAlt, create.PictureTitle, create.ShortDescription, create.Body);
                _blog.Add(article);
                _blog.SaveChanges();
                // TempData["Success"] = "مقاله با موفقیت ذخیره شد";
                //  SuccessMessage = "مقاله با موفقیت ذخیره شد";
                return RedirectToPage("./Index");
            }
            else
            {
              //  TempData["Error"] = "لطفا مقادیر خواسته شده را کامل کنید;
                ErrorMessage = "لطفا مقادیر خواسته شده را کامل کنید";

                return Page();
            }
            return Page();
        }
    }
}
