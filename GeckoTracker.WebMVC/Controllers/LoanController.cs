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
    public class LoanController : Controller
    {
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LoanService(userID);
            var model = service.GetLoans();
            
            return View(model);
        }

        private LoanService CreateLoanService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new LoanService(userID);
            return service;
        }

        public ActionResult Create()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new GeckoService(userID);

            ViewBag.LoanedGeckoID = new SelectList(svc.GetGeckos(), "GeckoID", "GeckoName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoanCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLoanService();

            if (service.CreateLoan(model))
            {
                TempData["SaveResult"] = "Loan information has been entered sucessfully.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Loan information was not saved.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateLoanService();
            var model = svc.GetLoanByID(id);

            return View(model);
        }

        [ActionName("Edit")]
        public ActionResult Edit(int id)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new GeckoService(userID);

            var service = CreateLoanService();
            var detail = service.GetLoanByID(id);
            var model = new LoanEdit
            {
                LoanID = detail.LoanID,
                LoanedGeckoID = detail.LoanedGeckoID,
                LoanedGeckoName = detail.LoanedGeckoName,
                LeaseeName = detail.LeaseeName,
                LoanStart = detail.LoanStart,
                LoanDuration = detail.LoanDuration
            };

            ViewBag.LoanedGeckoID = new SelectList(svc.GetGeckos(), "GeckoID", "GeckoName", model.LoanedGeckoID);

            return View(model);
        }

        [ActionName("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoanEdit model)
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var svc = new GeckoService(userID);

            ViewBag.LoanedGeckoID = new SelectList(svc.GetGeckos(), "GeckoID", "GeckoName", model.LoanedGeckoID);

            if (!ModelState.IsValid)
                return View(model);

            if (model.LoanID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateLoanService();

            if (service.UpdateLoan(model))
            {
                TempData["SaveResult"] = "Loan information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Loan information could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateLoanService();
            var model = service.GetLoanByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoan(int id)
        {
            var service = CreateLoanService();
            service.DeleteLoan(id);

            TempData["SaveResult"] = "This loan's information was deleted";

            return RedirectToAction("Index");
        }
    }
}