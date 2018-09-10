using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCRUDApp.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [Display(Name ="NAME")]
        [StringLength(100)]
        public string BookName { get; set; }

        [Required]
        [Display(Name ="AUTHOR")]
        [StringLength(100)]
        public string AuthorName { get; set; }

        [Required]
        [Display(Name ="GENRE")]
        public int BookGenreId { get; set; }


        [ForeignKey("BookGenreId")]
        public virtual BookGenre BookGenre { get; set; }
    }
}