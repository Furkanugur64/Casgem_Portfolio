using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ReferancesController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var values = db.TblReference.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddReferances()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddReferances(TblReference tblReference)
        {
            tblReference.ReferenceImageURL = "https://i.hizliresim.com/eo1espy.png";
            db.TblReference.Add(tblReference);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult UpdateReferances(int id)
        {
            var referance=db.TblReference.Find(id);
            return View(referance);
        }
        [HttpPost]
        public ActionResult UpdateReferances(TblReference reference)
        {
            var value = db.TblReference.Find(reference.ReferenceID);
            value.ReferenceName=reference.ReferenceName;
            value.ReferenceCity=reference.ReferenceCity;
            value.ReferenceMessage=reference.ReferenceMessage;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult DeleteReferances(int id)
        {
            var referance = db.TblReference.Find(id);
            db.TblReference.Remove(referance);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}