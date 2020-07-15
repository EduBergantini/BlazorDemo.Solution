using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorDemo.Application.Entities
{
    public class Article
    {
        public Article()
        {
            Paragraphs = new List<Paragraph>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }

        public ICollection<Paragraph> Paragraphs { get; set; }  
    }
}
