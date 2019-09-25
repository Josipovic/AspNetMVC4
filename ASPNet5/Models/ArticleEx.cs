using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNet5.Models
{
    public class ArticleEx
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public  DateTime PublishTime { get; set; }
        public bool Published { get; set; }
    }
}