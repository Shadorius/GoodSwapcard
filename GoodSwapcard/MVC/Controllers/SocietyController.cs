using BusinessLayer;
using ModelClient;
using MVC.Models;
using MVC.Models.Views;
using MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SocietyController : Controller
    {
        BLRSociety repo = new BLRSociety();
        BLRLocality repoLoc = new BLRLocality();
        BLRUtilisateur repoUser = new BLRUtilisateur();

        // GET: Society
        public ActionResult Index()
        {
            AddListSociety Societies = new AddListSociety();
            Societies.listSociety = repo.GetAll().OrderBy(s => s.SocietyName).Select(x => MappingModel.SocietyCtoMVC(x)).ToList();
            Societies.ajoutSociety.Localities = repoLoc.GetAll().Select(x => MappingModel.LocalityCtoM(x)).ToList();
            Societies.ajoutSociety.Utilisateurs = repoUser.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();

            if (TempData["Society"] != null)
            {
                Societies.ajoutSociety.addSociety = TempData["Society"] as Society;
                Societies.ActionCode = (int)TempData["SocietyAction"];
            }

            return View(Societies);
        }

        // GET: Society/Details/5
        public ActionResult Details(int? id)
        {
             if (id != null)
             {
                AddListSociety society = new AddListSociety();
                society.ajoutSociety.addSociety = MappingModel.SocietyCtoMVC(repo.Get((int)id));
                return PartialView("_Details", society);
             }
             return HttpNotFound();
            
        }


        // GET: Society/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                AddListSociety society = new AddListSociety();
                society.ajoutSociety.addSociety = MappingModel.SocietyCtoMVC(repo.Get((int)id));
                society.ajoutSociety.Localities = repoLoc.GetAll().Select(x => MappingModel.LocalityCtoM(x)).ToList();
                society.ajoutSociety.Utilisateurs = repoUser.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();
                return PartialView("_Edit", society);
            }
            return HttpNotFound();
        }

        // POST: Society/Edit/5
        [HttpPost]
        public ActionResult Edit(AddListSociety society)
        {
            society.ajoutSociety.Localities = repoLoc.GetAll().Select(x => MappingModel.LocalityCtoM(x)).ToList();
            society.ajoutSociety.Utilisateurs = repoUser.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();
            int id = society.ajoutSociety.addSociety.LLoc.Id;
            society.ajoutSociety.addSociety.LLoc.LocalityName = society.ajoutSociety.Localities.Where(x => x.Id == id).Select(n => n.LocalityName).SingleOrDefault();
            society.ajoutSociety.addSociety.Boss.LastName = society.ajoutSociety.Utilisateurs.Where(x => x.Id == id).Select(n => n.LastName).SingleOrDefault(); 
            if (ModelState.IsValid)
            {
                repo.Update(MappingModel.SocietyMVCtoC(society.ajoutSociety.addSociety));

            }
            else
            {
                TempData["Society"] = society.ajoutSociety.addSociety;
                //Action 1: Edit, Action 2: Insert
                TempData["SocietyAction"] = 1;
            }

            return RedirectToAction("Index");

        }

        // POST: Society/Create
        [HttpPost]
        public ActionResult Create(AddSociety society)
        {
            AddListSociety ListSociety = new AddListSociety();
            ListSociety.ajoutSociety = society;
            ListSociety.ajoutSociety.Localities = repoLoc.GetAll().Select(x => MappingModel.LocalityCtoM(x)).ToList();
            ListSociety.ajoutSociety.Utilisateurs = repoUser.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();
            int IdLoc = society.addSociety.LLoc.Id;
            ListSociety.ajoutSociety.addSociety.LLoc.Id = IdLoc;
            ListSociety.ajoutSociety.addSociety.LLoc.LocalityName = ListSociety.ajoutSociety.Localities.Where(x => x.Id == IdLoc).Select(n => n.LocalityName).SingleOrDefault();
            int IdBoss = society.addSociety.Boss.Id;
            ListSociety.ajoutSociety.addSociety.Boss.Id = IdBoss;
            ListSociety.ajoutSociety.addSociety.Boss.LastName = ListSociety.ajoutSociety.Utilisateurs.Where(x => x.Id == IdBoss).Select(n => n.LastName).SingleOrDefault();

            if (ModelState.IsValid)
            {
                repo.Insert(MappingModel.SocietyMVCtoC(society.addSociety));
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", ListSociety);
            }
        }


        // GET: Society/Delete/5
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Society/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(MappingModel.SocietyCtoMVC(repo.Get(id)));
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
