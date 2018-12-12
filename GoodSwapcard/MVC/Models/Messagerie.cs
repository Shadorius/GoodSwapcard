using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Messagerie
    {
        public int Id { get; set; }
        public Utilisateur UserOne { get; set; }
        public Utilisateur UserTwo { get; set; }
        public string Content { get; set; }
    }
}