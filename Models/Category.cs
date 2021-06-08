using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUDProj.Models
{
    //[Table("catehories")]
    public class Category
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
        public List<Book> Books { get; set; }
    }
}
