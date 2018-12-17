using BusinessLayer;
using MVC.Models;
using MVC.Models.Views;
using MVC.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UtilisateurController : Controller
    {
        BLRUtilisateur repo = new BLRUtilisateur();
        BLRStatut repoS = new BLRStatut();

        // GET: Utilisateur
        public ActionResult Index()
        {
            AddListUser viewAddUser = new AddListUser();
            viewAddUser.ajoutUser.Statuts = repoS.GetAll().Select(x => MappingModel.StatutCtoM(x)).ToList();
            viewAddUser.ajoutUser.Utilisateur = new Utilisateur();
            viewAddUser.listUsers = repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();

            return View(viewAddUser);
        }

        public ActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult LoGin(LogIn log)
        {

            return PartialView();
        }


        public ActionResult Profil()
        {

            return View();
        }

        public ActionResult Participant()
        {
            return View(repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList());
        }


        public ActionResult Inscription()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Inscription(UtilisateurForInscription util)
        {

            if (ModelState.IsValid)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = HashageMD5.GetMd5Hash(md5Hash, util.PsW);

                    if (HashageMD5.VerifyMd5Hash(md5Hash, util.PsW, hash))
                    {
                        if (util.Birthdate.HasValue)
                        {
                            DateTime date = util.Birthdate.Value;
                            util.Birthdate = date;
                        }

                        Utilisateur uti = MappingModel.UtilisateurFI(util);

                        util.PsW = hash;
                        repo.Insert(MappingModel.UtilisateurtoS(uti));
                        ViewBag.ErrorHash = "Le hashage n'a pas été correctement fait";
                    }
                    else
                    {
                        return View(util);
                    }
                }

                return RedirectToAction("Index");
            }
            return View(util);
        }

        // POST: Utilisateur/Create
        [HttpPost]
        public ActionResult Create(AddUser util)
        {
            AddListUser viewAddUser = new AddListUser();
            viewAddUser.ajoutUser = util;
            viewAddUser.ajoutUser.Statuts = repoS.GetAll().Select(x => MappingModel.StatutCtoM(x)).ToList();
            viewAddUser.listUsers = repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();
            int id = int.Parse(util.Utilisateur.statut.Id.ToString());
            viewAddUser.ajoutUser.Utilisateur.statut.Id = id;
            viewAddUser.ajoutUser.Utilisateur.statut.StatutName = viewAddUser.ajoutUser.Statuts.Where(x => x.Id == id).Select(n => n.StatutName).SingleOrDefault();

            if (ModelState.IsValid)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = HashageMD5.GetMd5Hash(md5Hash, util.Utilisateur.PsW);

                    if (HashageMD5.VerifyMd5Hash(md5Hash, util.Utilisateur.PsW, hash))
                    {
                        if(util.Utilisateur.Birthdate.HasValue)
                        {
                            DateTime date = util.Utilisateur.Birthdate.Value;
                            util.Utilisateur.Birthdate = date;
                        }

                        util.Utilisateur.PsW = hash;
                        repo.Insert(MappingModel.UtilisateurtoS(util.Utilisateur));
                        ViewBag.ErrorHash = "Le hashage n'a pas été correctement fait";
                    }
                    else
                    {
                        ViewBag.CodeError = 1;
                        return View("Index", viewAddUser);
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.CodeError = 1;
            return View("Index", viewAddUser);
        }

        // GET: Utilisateur/Edit/5
        public ActionResult Edit(int id)
        {
            return View(MappingModel.UtilisateurCtoMVC(repo.Get(id)));            
        }

        // POST: Utilisateur/Edit/5
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

        // GET: Utilisateur/Delete/5
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
