using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsContentManagement.Models
{
    public class News
    {
        public int Id { get; set; }
        [DisplayName("Haber Başlığı")]
        public string Title { get; set; }
       
        [DisplayName("Haber İçeriği")]
        [UIHint("tinymce_full_compressed"),AllowHtml]
        public string Content { get; set; }

        public virtual Category Categories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Author Authors { get; set; }
        [DisplayName("Kategori Seçiniz")]
        public int CategoryId { get; set; }
        [DisplayName("Yazar Seçiniz")]
        public int AuthorId { get; set; }
    }
}