using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Blog.Models
{
    public class CreateArticle
    {
        [Display( Name ="عنوان")]
        [Required(ErrorMessage ="عنوان مقاله اجباری می باشد")]
        public string Title { get; set; }
        [Required(ErrorMessage = " عکس مقاله اجباری می باشد")]

        [Display(Name = "مسیر عکس")]
        public string Picture { get; set; }
        [Display(Name = "Alt عکس")]

        public string PictureAlt { get; set; }
        [Display(Name = "عنوان عکس")]

        public string PictureTitle { get; set; }

        [Display(Name = "نوضیحات کوتاه")]
        [Required(ErrorMessage = "توضیحات کوتاه مقاله اجباری می باشد")]

        public string ShortDescription { get; set; }

        [Display(Name = "متن مقاله")]

        public string Body { get; set; }

    }
}
