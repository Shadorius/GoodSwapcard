using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models.Views
{
    public class LogIn
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Login { get; set; }
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required]
        public string PWD { get; set; }
    }
}