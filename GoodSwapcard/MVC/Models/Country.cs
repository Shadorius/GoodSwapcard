using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Pays")]
        public string CountryName { get; set; }

    }
}