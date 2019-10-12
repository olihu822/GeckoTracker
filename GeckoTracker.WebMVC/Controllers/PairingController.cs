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
    public class PairingController : Controller
    {
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PairingService(userID);
            var model = service.GetPairings();

            return View(model);
        }

        private PairingService CreatePairingService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PairingService(userID);
            return service;
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GeckoService(userID);

            ViewBag.MaleGeckoID = new SelectList( service.GetMaleGeckos(),"GeckoID", "GeckoName");
            ViewBag.FemaleGeckoID = new SelectList( service.GetFemaleGeckos(),"GeckoID", "GeckoName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PairingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePairingService();

            if (service.CreatePairing(model))
            {
                TempData["SaveResult"] = "Pairing information has been entered sucessfully.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Pairing information was not saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePairingService();
            var model = svc.GetPairingById(id);

            return View(model);
        }

        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new GeckoService(userID);

            var service = CreatePairingService();
            var detail = service.GetPairingById(id);
            var model = new PairingEdit
            {
                PairingID = detail.PairingID,
                MaleGeckoID = detail.MaleGeckoID,
                MaleGeckoName = detail.MaleGeckoName,
                FemaleGeckoID = detail.FemaleGeckoID,
                FemaleGeckoName = detail.FemaleGeckoName,
                Season = detail.Season
            };

            ViewBag.MaleGeckoID = new SelectList(svc.GetMaleGeckos(), "GeckoID", "GeckoName", model.MaleGeckoID);
            ViewBag.FemaleGeckoID = new SelectList(svc.GetFemaleGeckos(), "GeckoID", "GeckoName", model.FemaleGeckoID);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, PairingEdit model)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new GeckoService(userID);

            ViewBag.MaleGeckoID = new SelectList(svc.GetMaleGeckos(), "GeckoID", "GeckoName", model.MaleGeckoID);
            ViewBag.FemaleGeckoID = new SelectList(svc.GetFemaleGeckos(), "GeckoID", "GeckoName", model.FemaleGeckoID);

            if (!ModelState.IsValid)
                return View(model);

            if (model.PairingID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePairingService();

            if (service.UpdatePairing(model))
            {
                TempData["SaveResult"] = "Pairing information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Pairing information could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePairingService();
            var model = svc.GetPairingById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePairing(int id)
        {
            var service = CreatePairingService();
            service.DeletePairing(id);

            TempData["SaveResult"] = "This pairing's information was deleted";

            return RedirectToAction("Index");
        }
    }
}