using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class Notifications
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string Content { get; set; }
        public Utilisateur UNotif { get; set; }
    }
}