using CRUDProj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDProj.ViewsModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[^<>,<|>]+$", ErrorMessage = "Html tags are not allowed.")]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        [RegularExpression("^[^<>,<|>]+$", ErrorMessage = "Html tags are not allowed.")]
        public string Description { get; set; }
        [Required]
        [RegularExpression("^[^<>,<|>]+$", ErrorMessage = "Html tags are not allowed.")]
        public string Author { get; set; }
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }
       
        public IList<Category> Categories { get; set; }


    }
}