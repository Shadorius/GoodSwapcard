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
        [StringLength(50)]
        [RegularExpression(@"[a-zA-Z]", ErrorMessage ="couco")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression(@"[a-zA-Z]")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A - Z])(?=.*[a - z])(?=.*\d)(?=.*[-+!*$@% _])([-+!*$@% _\w]{8,15})$", ErrorMessage ="coucou")] //https://codes-sources.commentcamarche.net/source/49715-validation-de-mot-de-passe
        [Display(Name ="Mot de passe")]
        public string PsW { get; set; }
        [Required]
        [Compare(nameof(PsW))]
        public string ConfirmPsW { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }
        [Required]
        [Display(Name = "Numéro de tel")]
        [RegularExpression(@"[\d]{5,15}")]
        public string Phone { get; set; }
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
    }
}

