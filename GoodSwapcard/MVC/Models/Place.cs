using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class Place
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Nom du lieu")]
        public string PlaceName { get; set; }
        [Required]
        [Display(Name = "Rue")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Numéro/Boîte")]
        public string Number { get; set; }
        [Required]
        [Display(Name = "Ville")]
        public Locality PLocality { get; set; }
    }
}