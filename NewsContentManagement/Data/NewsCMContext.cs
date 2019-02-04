using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewsContentManagement.Models;
namespace NewsContentManagement.Data
{
    public class NewsCMContext:DbContext
    {
        public NewsCMContext() : base("NewsCMDatabase")
        {

        }
        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}