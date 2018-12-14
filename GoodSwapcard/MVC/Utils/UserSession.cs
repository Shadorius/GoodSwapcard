using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Utils
{
    public class UserSession
    {
        private const string _current = "CurrentUser";
        public static Utilisateur CurrentUser
        {
            get { return (Utilisateur)HttpContext.Current.Session[_current]; }
            set { HttpContext.Current.Session[_current] = value; }
        }
    }
}