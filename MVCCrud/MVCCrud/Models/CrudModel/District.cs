using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.CrudModel
{
    public class District
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
    }
}