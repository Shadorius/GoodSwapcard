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
        [RegularExpression(@"[a-zA-Z]{1,50}", ErrorMessage ="Le nom ne peut contenir que de 1 à 50 à  caracthère")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]{1,50}")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[-+!*$@%_])([-+!*$@%_\w]{8,15})$", ErrorMessage ="coucou")] //https://codes-sources.commentcamarche.net/source/49715-validation-de-mot-de-passe
        [Display(Name ="Mot de passe")]
        [DataType(DataType.Password)]
        public string PsW { get; set; }
        [Required]
        [Compare(nameof(PsW))]
        [DataType(DataType.Password)]
        public string ConfirmPsW { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare(nameof(Email))]
        public string ConfirmEmail { get; set; }
        [Display(Name = "Numéro de tel")]
        [RegularExpression(@"[\d]{5,15}")]
        public string Phone { get; set; }
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }
        public Statut statut { get; set; }
    }
}

