using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsContentManagement.Models
{
    public class News
    {
        public int Id { get; set; }
        [DisplayName("Haber Başlığı")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        [DisplayName("Haber İçeriği")]
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