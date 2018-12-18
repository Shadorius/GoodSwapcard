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
        [Display(Name ="Statut")]
        public int Id { get; set; }
        public string StatutName { get; set; }
    }
}