using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class Locality
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Ville")]
        public string LocalityName { get; set; }
        [Required]
        [Display(Name = "Code Postal")]
        public string CP { get; set; }
        [Required]
        [Display(Name ="Pays")]
        public Country LCountry { get; set; } 
    }
}