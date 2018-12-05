using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Mot de passe")]
        public string PsW { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}