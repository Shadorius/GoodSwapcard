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
        //Mapping Utilisateurs
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

        //Mapping Pays
        internal static CountryMC CountryStoC(CountryMS countryMS)
        {
            CountryMC countryMC = new CountryMC();

            countryMC.Id = countryMS.Id;
            countryMC.CountryName = countryMS.CountryName;

            return countryMC;
        }

        internal static CountryMS CountryCtoS(CountryMC countryMC)
        {
            CountryMS countryMS = new CountryMS();

            countryMS.Id = countryMC.Id;
            countryMS.CountryName = countryMC.CountryName;

            return countryMS;
        }

        //Mapping Evenement
        internal static EvenementMC EvenementStoC(EvenementMS evenementMS)
        {
            EvenementMC evenementMC = new EvenementMC();

            evenementMC.Id = evenementMS.Id;
            evenementMC.EvenementName = evenementMS.EvenementName;
            evenementMC.EventDesc = evenementMS.EventDesc;
            evenementMC.DateEvent = evenementMS.DateEvent;
            evenementMC.IdUserCreator = evenementMS.IdUserCreator;
            evenementMC.IdPlace = evenementMS.IdPlace;

            return evenementMC;
        }
         
        internal static EvenementMS EvenementCtoS(EvenementMC evenementMC)
        {
            EvenementMS evenementMS = new EvenementMS();

            evenementMS.Id = evenementMC.Id;
            evenementMS.EvenementName = evenementMC.EvenementName;
            evenementMS.EventDesc = evenementMC.EventDesc;
            evenementMS.DateEvent = evenementMC.DateEvent;
            evenementMS.IdUserCreator = evenementMC.IdUserCreator;
            evenementMS.IdPlace = evenementMC.IdPlace;

            return evenementMS;
        }

        //Mapping EventUser
        internal static EventUserMC EventUserStoC(EventUserMS eventUserMS)
        {
            EventUserMC eventUserMC = new EventUserMC();

            eventUserMC.Id = eventUserMS.Id;
            eventUserMC.IdUser = eventUserMS.IdUser;
            eventUserMC.IdEvent = eventUserMS.IdEvent;
            eventUserMC.IdStatut = eventUserMS.IdStatut;

            return eventUserMC;
        }

        internal static EventUserMS EventUserCtoS(EventUserMC eventUserMC)
        {
            EventUserMS eventUserMS = new EventUserMS();

            eventUserMS.Id = eventUserMC.Id;
            eventUserMS.IdUser = eventUserMC.IdUser;
            eventUserMS.IdEvent = eventUserMC.IdEvent;
            eventUserMS.IdStatut = eventUserMC.IdStatut;

            return eventUserMS;
        }

        //Mapping HourTime
        internal static HourTimeMC HourTimeStoC(HourTimeMS hourTimeMS)
        {
            HourTimeMC hourTimeMC = new HourTimeMC();

            hourTimeMC.Id = hourTimeMS.Id;
            hourTimeMC.Hour = hourTimeMS.Hour;
            hourTimeMC.Minute = hourTimeMS.Minute;

            return hourTimeMC;
        }

        internal static HourTimeMS HourTimeCtoS(HourTimeMC hourTimeMC)
        {
            HourTimeMS hourTimeMS = new HourTimeMS();

            hourTimeMS.Id = hourTimeMC.Id;
            hourTimeMS.Hour = hourTimeMC.Hour;
            hourTimeMS.Minute = hourTimeMC.Minute;

            return hourTimeMS;
        }

        //Mapping Locality
        internal static LocalityMC LocalityStoC(LocalityMS localityMS)
        {
            LocalityMC localityMC = new LocalityMC();

            localityMC.Id = localityMS.Id;
            localityMC.LocalityName = localityMS.LocalityName;
            localityMC.CP = localityMS.CP;
            localityMC.IdCountry = localityMS.IdCountry;

            return localityMC;
        }

        internal static LocalityMS LocalityCtoS(LocalityMC localityMC)
        {
            LocalityMS localityMS = new LocalityMS();

            localityMS.Id = localityMC.Id;
            localityMS.LocalityName = localityMC.LocalityName;
            localityMS.CP = localityMC.CP;
            localityMS.IdCountry = localityMC.IdCountry;

            return localityMS;
        }

        //Mapping Place
        internal static PlaceMC PlaceStoC (PlaceMS placeMS)
        {
            PlaceMC placeMC = new PlaceMC();

            placeMC.Id = placeMS.Id;
            placeMC.PlaceName = placeMS.PlaceName;
            placeMC.Street = placeMS.Street;
            placeMC.Number = placeMS.Number;
            placeMC.IdLoc = placeMS.IdLoc;

            return placeMC;
        }

        internal static PlaceMS PlaceCtoS(PlaceMC placeMC)
        {
            PlaceMS placeMS = new PlaceMS();

            placeMS.Id = placeMC.Id;
            placeMS.PlaceName = placeMC.PlaceName;
            placeMS.Street = placeMC.Street;
            placeMS.Number = placeMC.Number;
            placeMS.IdLoc = placeMC.IdLoc;

            return placeMS;
        }

        //Mapping RDV
        internal static RdVMC RdVStoC(RdVMS rdvMS)
        {
            RdVMC rdvMC = new RdVMC();

            rdvMC.Id = rdvMS.Id;
            rdvMC.IdHour = rdvMS.IdHour;
            rdvMC.IdCandidat = rdvMS.IdCandidat;
            rdvMC.IdRep = rdvMS.IdRep;
            rdvMC.RdvState = rdvMS.RdvState;

            return rdvMC;
        }

        internal static RdVMS RdVCtoS(RdVMC rdvMC)
        {
            RdVMS rdvMS = new RdVMS();

            rdvMS.Id = rdvMC.Id;
            rdvMS.IdHour = rdvMC.IdHour;
            rdvMS.IdCandidat = rdvMC.IdCandidat;
            rdvMS.IdRep = rdvMC.IdRep;
            rdvMS.RdvState = rdvMC.RdvState;

            return rdvMS;
        }

        //Mapping Statut
        internal static StatutMC StatutStoC(StatutMS statutMS)
        {
            StatutMC statutMC = new StatutMC();

            statutMC.Id = statutMS.Id;
            statutMC.StatutName = statutMS.StatutName;

            return statutMC;
        }

        internal static StatutMS StatutCtoS(StatutMC statutMC)
        {
            StatutMS statutMS = new StatutMS();

            statutMS.Id = statutMC.Id;
            statutMS.StatutName = statutMC.StatutName;

            return statutMS;
        }

        internal static NotificationsMC NotifictionsStoC(NotifictionsMS Notifs)
        {
            return new NotificationsMC()
            {
                Id = Notifs.Id,
                Content = Notifs.Content,
                IdUser = Notifs.IdUser
            };
        }

        internal static NotifictionsMS NotifictionsCtoS(NotificationsMC Notifs) {
            return new NotifictionsMS() {
                Id = Notifs.Id,
                Content = Notifs.Content,
                IdUser = Notifs.IdUser
            };
        }
    }
}
