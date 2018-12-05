using ModelClient;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Utils
{
    public class MappingModel
    {
        //Mapping Utilisateurs
        internal static Utilisateur UtilisateurCtoMVC(UtilisateurMC utiMS)
        {
            Utilisateur uti = new Utilisateur();

            uti.Id = utiMS.Id;
            uti.LastName = utiMS.LastName;
            uti.FirstName = utiMS.FirstName;
            uti.PsW = utiMS.PsW;
            uti.Email = utiMS.Email;
            uti.Phone = utiMS.Phone;
            uti.Birthdate = utiMS.Birthdate;


            return uti;
        }

        internal static UtilisateurMC UtilisateurtoS(Utilisateur utiMC)
        {
            UtilisateurMC utilMC = new UtilisateurMC();

            utilMC.Id = utiMC.Id;
            utilMC.LastName = utiMC.LastName;
            utilMC.FirstName = utiMC.FirstName;
            utilMC.PsW = utiMC.PsW;
            utilMC.Email = utiMC.Email;
            utilMC.Phone = utiMC.Phone;
            utilMC.Birthdate = utiMC.Birthdate;


            return utilMC;
        }
    }
}