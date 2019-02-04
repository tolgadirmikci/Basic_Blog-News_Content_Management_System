using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewsContentManagement.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Kategori İsmi")]
        public string categoryName { get; set; }

        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}