using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeckoTracker.Models;
using GeckoTracker.Services;
using Microsoft.AspNet.Identity;

namespace GeckoTracker.WebMVC.Controllers
{
    [Authorize]
    public class GeckoController : Controller
    {
        // GET: Gecko
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GeckoService(userID);
            var model = service.GetGeckos();
            return View(model);
        }

        //GET: GeckoHelperMethod
        private GeckoService CreateGeckoService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GeckoService(userID);
            return service;
        }


        // GET: Gecko/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gecko/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GeckoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGeckoService();

            if (service.CreateGecko(model))
            { //changed from viewbag in an attempt at alert in bs4, with update from 3 not working
                TempData["SaveResult"] = "Gecko information has been entered successfully.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Gecko information was not saved.");

            return View(model);
        }

        //GET: Gecko/Edit
        public ActionResult Details(int id)
        {
            var svc = CreateGeckoService();
            var model = svc.GetGeckoById(id);

            return View(model);
        }

        //GET: Gecko/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateGeckoService();
            var detail = service.GetGeckoById(id);
            var model =
                new GeckoEdit
                {
                    GeckoID = detail.GeckoID,
                    GeckoName = detail.GeckoName,
                    GeckoSexIsMale = detail.GeckoSexIsMale,
                    GeckoWeight = detail.GeckoWeight,
                    HatchDate = detail.HatchDate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GeckoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GeckoID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGeckoService();

            if (service.UpdateGecko(model))
            {
                TempData["SaveResult"] = "Gecko information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gecko information could not be updated.");
            return View(model);
        }

        //GET: Gecko/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGeckoService();
            var model = svc.GetGeckoById(id);

            return View(model);
        }

        //POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGecko(int id)
        {
            var service = CreateGeckoService();

            service.DeleteGecko(id);

            TempData["SaveResult"] = "This gecko's information was deleted";

            return RedirectToAction("Index");
        }
    }
}