using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Messagerie
    {
        public int Id { get; set; }
        public Utilisateur UserOne { get; set; }
        public Utilisateur UserTwo { get; set; }
        [Display(Name ="Message")]
        public string Content { get; set; }
        [Display(Name ="Date d'envoie")]
        public DateTime DateSend { get; set; }
    }
}