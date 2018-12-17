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
        // GET: Society
        public ActionResult Index()
        {
            AddListSociety Societies = new AddListSociety();
            Societies.listSociety = repo.GetAll().OrderBy(s => s.SocietyName).Select(x => MappingModel.SocietyCtoMVC(x)).ToList();
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

        // GET: Society/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Society/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Society/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Society/Edit/5
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
