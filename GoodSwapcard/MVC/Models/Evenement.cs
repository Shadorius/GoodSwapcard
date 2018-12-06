using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nom")]
        public string EvenementName { get; set; }
        [Display(Name = "Description")]
        public string EventDesc { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime? DateEvent { get; set; }
        public Utilisateur Creator { get; set; }
        [Required]
        [Display(Name = "Lieu")]
        public Place EventPlace { get; set; }
    }
}