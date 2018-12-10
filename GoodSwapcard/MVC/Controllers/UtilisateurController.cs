using BusinessLayer;
using MVC.Models;
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

        // GET: Utilisateur
        public ActionResult Index()
        {
            return View(repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList());
        }

        public ActionResult Participant()
        {
            return View(repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList());
        }


        // GET: Utilisateur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Utilisateur/Create
        [HttpPost]
        public ActionResult Create(Utilisateur util)
        {
            if (ModelState.IsValid)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = HashageMD5.GetMd5Hash(md5Hash, util.PsW);

                    if (HashageMD5.VerifyMd5Hash(md5Hash, util.PsW, hash))
                    {
                        if(util.Birthdate != null)
                        {
                            DateTime date = (DateTime)util.Birthdate;
                            util.Birthdate = date;
                        }

                        util.PsW = hash;
                        repo.Insert(MappingModel.UtilisateurtoS(util));
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

        // POST: Utilisateur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid)
                {
                    return View(MappingModel.UtilisateurCtoMVC(repo.Get(id)));
                }
                repo.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
