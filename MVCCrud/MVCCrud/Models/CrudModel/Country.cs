using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Models.CrudModel
{
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Country code"), Required]
        [StringLength(5)]
        [Index(IsUnique = true)]
        [Remote("IsCodeExists", "Country", HttpMethod = "POST", ErrorMessage = "Code already in use")]
        public string CountryCode { get; set; }

        [Display(Name = "Country name"), Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Remote("IsNameExists", "Country", HttpMethod = "POST", ErrorMessage = "Name already in use")]
        public string CountryName { get; set; }
    }
}