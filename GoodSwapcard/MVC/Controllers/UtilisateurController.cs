﻿using BusinessLayer;
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
            //return View(repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList());
            AddListUser viewAddUser = new AddListUser();
            viewAddUser.ajoutUser.Statuts = repoS.GetAll().Select(x => MappingModel.StatutCtoM(x)).ToList();
            viewAddUser.ajoutUser.Utilisateur = new Utilisateur();
            viewAddUser.listUsers = repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList();

            return View(viewAddUser);
        }

        public ActionResult Participant()
        {
            return View(repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).ToList());
        }

        public ActionResult test()
        {
            AddUser testView = new AddUser();

            testView.Statuts = repoS.GetAll().Select(x => MappingModel.StatutCtoM(x)).ToList();
            testView.Utilisateur = new Utilisateur();

            return View(testView);
        }

        //GET: Utilisateur/Create
        //public ActionResult Create(AddUser viewAddUser)
        //{
        //    viewAddUser.Statuts = repoS.GetAll().Select(x => MappingModel.StatutCtoM(x)).ToList();
        //    viewAddUser.Utilisateur = new Utilisateur();

        //    return View();
        //}

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
                        return View("Index", viewAddUser);
                    }
                }

                return RedirectToAction("Index");
            }

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
