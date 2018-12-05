using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class HourTime
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Heure")]
        public int Hour { get; set; }
        [Required]
        [Display(Name = "Minutes")]
        public int Minute { get; set; }
    }
}