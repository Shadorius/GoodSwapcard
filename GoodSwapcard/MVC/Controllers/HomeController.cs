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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult LoGin(LogIn log)
        {
            Utilisateur u = repo.GetAll().Select(x => MappingModel.UtilisateurCtoMVC(x)).Where(x => x.Email == log.Login).SingleOrDefault();
            if (u  == null)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = HashageMD5.GetMd5Hash(md5Hash, log.PWD);

                    if (HashageMD5.VerifyMd5Hash(md5Hash, log.PWD, hash))
                    {
                        log.PWD = hash;                        
                        ViewBag.ErrorHash = "Le hashage n'a pas été correctement fait";
                    }
                    else
                    {
                        ViewBag.CodeErrorConnection = 1;
                        ViewBag.errorConnection = " L\'adresse ou mot de passe incorrecte";
                        return View("Index");
                    }
                }

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
    }
}