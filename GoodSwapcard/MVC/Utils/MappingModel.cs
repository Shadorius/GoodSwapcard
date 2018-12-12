﻿using BusinessLayer;
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
        static BLRUtilisateur repoUtil = new BLRUtilisateur();
        static BLREvenement repoEvent = new BLREvenement();
        static BLRStatut repoStatut = new BLRStatut();
        static BLRPlace repoPlace = new BLRPlace();
        static BLRHourTime repoHourTime = new BLRHourTime();
        static BLRLocality repoLocality = new BLRLocality();
        static BLRCountry repoCountry = new BLRCountry();
        static BLRSociety BLRSociety = new BLRSociety();


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
            uti.statut = StatutCtoM(repoStatut.Get(utiMS.statut));


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
            utilMC.statut = utiMC.statut.Id;


            return utilMC;
        }
        //Mapping Country
        internal static Country CountryCtoM(CountryMC c)
        {
            return new Country()
            {
                Id = c.Id,
                CountryName = c.CountryName
            };
        }
        internal static CountryMC CountryMtoC(Country c)
        {
            return new CountryMC()
            {
                Id = c.Id,
                CountryName = c.CountryName
            };
        }

        //Mapping Evenement
        internal static Evenement EvenementCtoM(EvenementMC c)
        {
            return new Evenement()
            {
                Id = c.Id,
                EvenementName = c.EvenementName,
                DateEvent = c.DateEvent,
                Creator = UtilisateurCtoMVC(repoUtil.Get(c.IdUserCreator)),
                EventPlace = PlaceCtoM(repoPlace.Get(c.IdPlace))
            };
        }
        internal static EvenementMC EvenementMtoC(Evenement c)
        {
            return new EvenementMC()
            {
                Id = c.Id,
                EvenementName = c.EvenementName,
                DateEvent = c.DateEvent,
                IdUserCreator = c.Creator.Id,
                IdPlace = c.EventPlace.Id
            };
        }

        //Mapping Statut
        internal static Statut StatutCtoM(StatutMC s)
        {
            return new Statut()
            {
                Id = s.Id,
                StatutName = s.StatutName
            };
        }
        internal static StatutMC StatutMtoC(Statut s)
        {
            return new StatutMC()
            {
                Id = s.Id,
                StatutName = s.StatutName
            };
        }

        //Mapping RdV
        internal static RdV RdVCtoM(RdVMC s)
        {
            return new RdV()
            {
                Id = s.Id,
                RdvHour = HourTimeCtoM(repoHourTime.Get(s.IdHour)),
                IdCandidat = UtilisateurCtoMVC(repoUtil.Get(s.IdCandidat)),
                IdRep = UtilisateurCtoMVC(repoUtil.Get(s.IdRep))
            };
        }
        internal static RdVMC RdVMtoC(RdV s)
        {
            return new RdVMC()
            {
                Id = s.Id,
                IdHour = s.RdvHour.Id,
                IdCandidat = s.IdCandidat.Id,
                IdRep = s.IdRep.Id
            };
        }

        //Mapping Place
        internal static Place PlaceCtoM(PlaceMC p)
        {
            return new Place()
            {
                Id = p.Id,
                PlaceName = p.PlaceName,
                Street = p.Street,
                Number = p.Number,
                PLocality = LocalityCtoM(repoLocality.Get(p.IdLoc))
            };
        }
        internal static PlaceMC PlaceMtoC(Place p)
        {
            return new PlaceMC()
            {
                Id = p.Id,
                PlaceName = p.PlaceName,
                Street = p.Street,
                Number = p.Number,
                IdLoc = p.PLocality.Id
            };
        }

        //Mapping Notifs
        internal static Notifications NotificationsCtoM(NotificationsMC p)
        {
            return new Notifications()
            {
                Id = p.Id,
                Content = p.Content,
                UNotif = UtilisateurCtoMVC(repoUtil.Get(p.IdUser))
            };
        }
        internal static NotificationsMC NotificationsMtoC(Notifications p)
        {
            return new NotificationsMC()
            {
                Id = p.Id,
                Content = p.Content,
                IdUser = p.UNotif.Id
            };
        }

        //Mapping Locality
        internal static Locality LocalityCtoM(LocalityMC p)
        {
            return new Locality()
            {
                Id = p.Id,
                LocalityName = p.LocalityName,
                CP = p.CP,
                LCountry = CountryCtoM(repoCountry.Get(p.IdCountry))
            };
        }
        internal static LocalityMC LocalityMtoC(Locality p)
        {
            return new LocalityMC()
            {
                Id = p.Id,
                LocalityName = p.LocalityName,
                CP = p.CP,
                IdCountry = p.LCountry.Id
            };
        }

        //Mapping HourTime
        internal static HourTime HourTimeCtoM(HourTimeMC p)
        {
            return new HourTime()
            {
                Id = p.Id,
                Hour = p.Hour,
                Minute = p.Minute
            };
        }
        internal static HourTimeMC HourTimeMtoC(HourTime p)
        {
            return new HourTimeMC()
            {
                Id = p.Id,
                Hour = p.Hour,
                Minute = p.Minute
            };
        }

        //Mapping EventUser
        internal static EventUser EventUserCtoM(EventUserMC p)
        {
            return new EventUser()
            {
                Id = p.Id,
                UserEvnt = UtilisateurCtoMVC(repoUtil.Get(p.IdUser)),
                Event = EvenementCtoM(repoEvent.Get(p.IdEvent)),
                UserStatut = StatutCtoM(repoStatut.Get(p.IdStatut))
            };
        }
        internal static EventUserMC EventUserMtoC(EventUser p)
        {
            return new EventUserMC()
            {
                Id = p.Id,
                IdUser = p.UserEvnt.Id,
                IdStatut = p.UserStatut.Id
            };
        }

        //Mapping StatutEvent
        internal static StatutEvent StatutEventCtoM(StatutEventMC s)
        {
            return new StatutEvent()
            {
                Id = s.Id,
                StatutEventName = s.StatutEventName
            };
        }
        internal static StatutEventMC StatutEventMtoC(StatutEvent s)
        {
            return new StatutEventMC()
            {
                Id = s.Id,
                StatutEventName = s.StatutEventName
            };
        }

        //Mapping Society
        internal static Society SocietyCtoM(SocietyMC s)
        {
            return new Society()
            {
                Id = s.Id,
                SocietyName = s.SocietyName,
                SocietyDesc = s.SocietyDesc,
                Phone = s.Phone,
                IdLoc = s.IdLoc,
                IdBoss = s.IdBoss
            };
        }


        //internal static SocietyMC S


        //Mapping Messagerie
        internal static Messagerie MessagerieCtoMVC(MessagerieMC p)
        {
            return new Messagerie()
            {
                Id = p.Id,
                UserOne = UtilisateurCtoMVC(repoUtil.Get(p.IdUserOne)),
                UserTwo = UtilisateurCtoMVC(repoUtil.Get(p.IdUserTwo)),
                Content = p.Content
            };
        }
        internal static MessagerieMC MessagerieMVCtoC(Messagerie p)
        {
            return new MessagerieMC()
            {
                Id = p.Id,
                IdUserOne = p.UserOne.Id,
                IdUserTwo = p.UserTwo.Id,
                Content = p.Content
            };
        }

    }
}