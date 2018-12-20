using BusinessLayer;
using MVC.Models;
using MVC.Models.Views;
using MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EvenementController : Controller
    {
        BLREvenement repoEvent = new BLREvenement();
        BLRPlace repoPlace = new BLRPlace();
        BLRLocality repoLocality = new BLRLocality();
        BLRCountry repoCountry = new BLRCountry();
        BLRUtilisateur repoUser = new BLRUtilisateur();
        BLREventUser repoEventUser = new BLREventUser();

        // GET: Evenement
        public ActionResult Index()
        {
            return View(repoEvent.GetAll().Select(x => MappingModel.EvenementCtoM(x)).ToList());
        }

        public PartialViewResult PartialDetail(int id)
        {
            return PartialView("_Details", MappingModel.EvenementCtoM(repoEvent.Get(id)));
        }

        // GET: Evenement/Details/5
        public ActionResult Details(int id)
        {

            //repoEvent.GetAll().Select(x => MappingModel.EvenementCtoM(x)).Where(y => y.id).ToList();
            //repoUser.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();

            ViewBag.idEvent = id;
            ViewBag.EventName = repoEvent.Get(id).EvenementName;
            return View();
        }

        public PartialViewResult ListUser(int id)
        {

            List<Utilisateur> u = repoEventUser.GetAllById(id).Select(x => MappingModel.UtilisateurCtoMVC(repoUser.Get(x.IdUser))).ToList();

            return PartialView("ListUser", u);
        }

        // GET: Evenement/Create
        public ActionResult Create()
        {
            AddEvent eventAdd = new AddEvent
            {
                ListEventPlace = repoPlace.GetAll().Select(x => MappingModel.PlaceCtoM(x)).Select(y => MappingModel.EventMVCtoC(y)).ToList()
            };

            return View(eventAdd);
        }

        // POST: Evenement/Create
        [HttpPost]
        public ActionResult Create(AddEvent eventAdd)
        {
            try
            {
                DateTime date = eventAdd.DateEvent.Value;
                eventAdd.DateEvent = date;
                repoEvent.Insert(MappingModel.EvenementMtoC(MappingModel.SetAddEvent(eventAdd)));

                return RedirectToAction("Index");
            }
            catch
            {
                AddEvent eventAddreload = new AddEvent
                {
                    ListEventPlace = repoPlace.GetAll().Select(x => MappingModel.PlaceCtoM(x)).Select(y => MappingModel.EventMVCtoC(y)).ToList()
                };
                return View(eventAddreload);
            }
        }

        // GET: Evenement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Evenement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Evenement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Evenement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
