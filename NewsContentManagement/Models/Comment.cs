using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NewsContentManagement.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [DisplayName("Yorum İçeriği")]
        public string commentContent { get; set; }
        public DateTime Date { get; set; }

        public virtual News News { get; set; }
        public int NewsId { get; set; }
    }
}