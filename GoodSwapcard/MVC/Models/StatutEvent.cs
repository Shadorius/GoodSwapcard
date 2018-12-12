using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class StatutEvent
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Statut")]
        public string StatutEventName { get; set; }
    }
}