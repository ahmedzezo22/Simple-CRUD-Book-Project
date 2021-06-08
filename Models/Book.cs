using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDProj.Models
{
    public class Book
    {
        public Book()
        {
            AddedTime = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[^<>,<|>]+$", ErrorMessage = "Html tags are not allowed.")]
        public string Title { get; set; }
        [Required]
        
        [MaxLength(200)]
        [RegularExpression("^[^<>,<|>]+$", ErrorMessage = "Html tags are not allowed.")]
        public  string Description{ get; set; }
        [Required]
        [RegularExpression("^[^<>,<|>]+$", ErrorMessage = "Html tags are not allowed.")]
        public string Author { get; set; }
        public byte CategoryId { get; set; }
        public Category Category { get; set; }

        public  DateTime AddedTime { get; set; }




    }
}
