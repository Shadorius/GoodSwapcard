using ModelClient;
using ModelServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal static class MappingModel
    {
        internal static  UtilisateurMC UtilisateurStoC(UtilisateurMS utiMS)
        {
            UtilisateurMC utiMC = new UtilisateurMC();

            utiMC.Id = utiMS.Id ;
            utiMC.LastName = utiMS.LastName;
            utiMC.FirstName = utiMS.FirstName;
            utiMC.PsW = utiMS.PsW;
            utiMC.Email = utiMS.Email;
            utiMC.Phone = utiMS.Phone;
            utiMC.Birthdate = utiMS.Birthdate;


            return utiMC;
        }

        internal static UtilisateurMS UtilisateurCtoS(UtilisateurMC utiMC)
        {
            UtilisateurMS utiMS = new UtilisateurMS();

            utiMS.Id = utiMC.Id;
            utiMS.LastName = utiMC.LastName;
            utiMS.FirstName = utiMC.FirstName;
            utiMS.PsW = utiMC.PsW;
            utiMS.Email = utiMC.Email;
            utiMS.Phone = utiMC.Phone;
            utiMS.Birthdate = utiMC.Birthdate;


            return utiMS;
        }
    }
}
