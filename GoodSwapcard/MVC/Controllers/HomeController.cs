using BusinessLayer;
using MVC.Models;
using MVC.Models.Views;
using MVC.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        BLRUtilisateur repo = new BLRUtilisateur();
        BLRMessagerie Mess_repo = new BLRMessagerie();
        BLRStatut repoStatut = new BLRStatut();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Messages()
        {
            List<Messagerie> list = new List<Messagerie>();
            if (UserSession.CurrentUser != null)
            {
                list = Mess_repo.GetAll(UserSession.CurrentUser.Id).OrderBy(x => x.DateSend).Select(x => MappingModel.MessagerieCtoMVC(x)).ToList();
            }
                        
            return View(list);
        }

        public ActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult LoGin(LogIn log)
        {
            Utilisateur u = repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).Where(x => x.Email == log.Login).SingleOrDefault();

            if (u != null)
            { 

                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = HashageMD5.GetMd5Hash(md5Hash, log.PWD);

                    if (HashageMD5.VerifyMd5Hash(md5Hash, u.PsW, hash))
                    {
                        UserSession.CurrentUser = u;
                        ViewBag.CodeErrorConnection = 1;
                        ViewBag.errorConnection = " t'es connecté fissdeup";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.CodeErrorConnection = 1;
                        ViewBag.errorConnection = " L\'adresse ou mot de passe incorrecte";
                        return View("Index");
                    }
                }
            }

            ViewBag.CodeErrorConnection = 1;
            ViewBag.errorConnection = " L\'adresse ou mot de passe incorrecte";
            return View("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                EditUser utilisateur = new EditUser();
                utilisateur.Utilisateur = MappingModel.UtilisateurModelToEdit(MappingModel.UtilisateurCtoMVC(repo.Get((int)id)));
                utilisateur.Utilisateur.PsW = "";
                utilisateur.Statuts = repoStatut.GetAll().Select(x => MappingModel.StatutCtoM(x)).ToList();
                return View(utilisateur);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(UtilisateurForEdit utilisateur)
        {
            if (ModelState.IsValid)
            {
                if (utilisateur.PsW != null)
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = HashageMD5.GetMd5Hash(md5Hash, utilisateur.PsW);
                        if (HashageMD5.VerifyMd5Hash(md5Hash, utilisateur.PsW, hash))
                        {
                            utilisateur.PsW = hash;
                        }
                        else
                        {
                            ViewBag.CodeError = 1;
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    int idUser = utilisateur.Id;
                    AddUser userDB = new AddUser();
                    userDB.Utilisateur = MappingModel.UtilisateurCtoMVC(repo.Get(idUser));
                    utilisateur.PsW = userDB.Utilisateur.PsW;
                }

                if (utilisateur.Birthdate.HasValue)
                {
                    DateTime date = utilisateur.Birthdate.Value;
                    utilisateur.Birthdate = date;
                }
               
                Utilisateur test = new Utilisateur();
                test = MappingModel.UtilisateurCtoMVC(repo.Get(utilisateur.Id));
                
                Utilisateur util = MappingModel.UtilisateurEdittoModel(utilisateur);
                util.statut.Id = test.statut.Id;

                repo.Update(MappingModel.UtilisateurtoS(util));
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Deconnexion()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}