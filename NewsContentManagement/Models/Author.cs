using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewsContentManagement.Models
{
    public class Author
    {
        public int Id { get; set; }
        [DisplayName("Yazar İsmi")]
        public string authorName { get; set; }

        public  virtual ICollection<News> News { get; set; }
    }
}