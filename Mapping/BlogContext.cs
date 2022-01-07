using Microsoft.EntityFrameworkCore;
using Razor_Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Blog.Mapping
{
    public class BlogContext:DbContext
    {
      public  DbSet<Article> Articles { get;set; }
        public BlogContext(DbContextOptions<BlogContext> context):base(context)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new ArticleMapping());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
