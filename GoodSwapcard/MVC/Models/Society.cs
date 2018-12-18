using ModelClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Society
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Société")]
        public string SocietyName { get; set; }
        [Display(Name = "Description")]
        public string SocietyDesc { get; set; }
        [Display(Name = "Description courte")]
        public string SocietyTinyDesc { get; set; }
        [Display(Name = "Lien image")]
        public string Img { get; set; }
        [Display(Name = "Site web")]
        public string WebSite { get; set; }
        [Display(Name = "Téléphone")]
        [RegularExpression(@"[\d]{5,15}", ErrorMessage = "Ne peut contenir que des décimaux")]
        public string Phone { get; set; }
        [Display(Name = "Rue")]
        public string Street { get; set; }
        [Display(Name = "Numéro")]
        public string Number { get; set; }
        [Required]
        public LocalityMC LLoc { get; set; }
        [Required]
        public UtilisateurMC Boss { get; set; }
    }
}