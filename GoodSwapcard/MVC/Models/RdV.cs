using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class RdV
    { 
        public int Id { get; set; }
        [Required]
        [Display(Name ="Heure de RDV")]
        public HourTime RdvHour { get; set; }
        [Required]
        [Display(Name = "Candidat")]
        public Utilisateur IdCandidat { get; set; }
        [Required]
        [Display(Name = "Candidat2")]
        public Utilisateur IdRep { get; set; }
        [Display(Name ="Accepté")]
        public bool RdvState { get; set; }

        public RdV()
        {
            RdvState = false;
        }
    }
}