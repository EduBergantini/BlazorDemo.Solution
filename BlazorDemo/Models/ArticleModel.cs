using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDemo.Model
{
    public class ArticleModel
    {
        [Required]
        [StringLength(60, ErrorMessage = "Título muito longo")]
        public string Title { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Título muito longo")]
        public string Description { get; set; }
    }
}
