using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Application.Entities
{
    public class Paragraph
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
