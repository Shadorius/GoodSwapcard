using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class Statut
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Statut")]
        public string StatutName { get; set; }
    }
}