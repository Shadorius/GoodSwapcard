﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SocietyUser
    {
        public int Id { get; set; }
        public Utilisateur UserSoc { get; set; }
        public Society CurrentSociety { get; set; }
    }
}