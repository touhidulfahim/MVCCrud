using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDApp.Models
{
    public class BookGenre
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookGenreId { get; set; }

        [Required]
        [Display(Name = "NAME")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsBookGenreNameExists", "BookGenre", HttpMethod = "POST", ErrorMessage = "Book Genre Name already exists!")]
        public string BookGenreName { get; set; }
        
    }
}