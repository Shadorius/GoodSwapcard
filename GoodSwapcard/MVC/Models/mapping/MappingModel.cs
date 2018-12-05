using ModelClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models.mapping
{
    internal static class MappingModel
    {
        //Mapping Country
        internal static Country CountryCtoM(CountryMC c) {
            return new Country() {
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
                DateEvent = c.DateEvent
                //Creator = Utilisateur.Get(c.IdUserCreator)
                //EventPlace = Evenement.Get(c.IdPlace)
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
                StatutName =s.StatutName
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
                Id = s.Id
                //RdvHour = RdV.Get(s.IdHour)
                //IdCandidat = RdV.Get(s.IdCandidat)
                //IdRep = RdV.Get(s.IdRep)
            };
        }
        internal static RdVMC RdVMtoM(RdV s)
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
        internal static Place RdVCtoM(PlaceMC p)
        {
            return new Place()
            {
                Id = p.Id,
                PlaceName = p.PlaceName,
                Street = p.Street,
                Number = p.Number
                //PLocality = Locality.Get(p.IdLoc)
            };
        }
        internal static PlaceMC RdVMtoM(Place p)
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
                Content = p.Content
                //UNotif = Utilisateur.Get(p.IdLoc)
            };
        }
        internal static NotificationsMC NotificationsMtoM(Notifications p)
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
                //LCountry = Country.Get(p.IdCountry)
            };
        }
        internal static LocalityMC LocalityMtoM(Locality p)
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
                Id=p.Id,
                Hour = p.Hour,
                Minute = p.Minute
            };
        }
        internal static HourTimeMC HourTimeMtoM(HourTime p)
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
                //UserEvnt = Utilisateur.Get(p.IdUser),
                //Event = Evenement.Get(p.IdEvent),
                //UserStatut = Statut.Get(p.IdStatut)
            };
        }
        internal static EventUserMC EventUserMtoM(EventUser p)
        {
            return new EventUserMC()
            {
                Id = p.Id,
                IdUser = p.UserEvnt.Id,
                IdStatut = p.UserStatut.Id
            };
        }
    }
}