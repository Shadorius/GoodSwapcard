using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EventUser
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Utilisateur")]
        public Utilisateur UserEvnt { get; set; }
        [Required]
        [Display(Name = "Evenement")]
        public Evenement Event { get; set; }
        [Required]
        [Display(Name = "Statut")]
        public Statut UserStatut { get; set; }
    }
}