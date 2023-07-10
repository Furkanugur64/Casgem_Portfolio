using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Casgem_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values=db.TblService.ToList();
            return View(values);
        }

        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService tblService)
        {
            db.TblService.Add(tblService);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int ServiceID)
        {
            var service = db.TblService.Find(ServiceID);
            db.TblService.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetService(int id)
        {
            var service = db.TblService.Find(id);
            return View("GetService",service);
        }

        [HttpPost]
        public ActionResult UpdateService(TblService s)
        {
            var service = db.TblService.Find(s.ServiceID);
            service.ServiceNumber = s.ServiceNumber;
            service.ServiceContent= s.ServiceContent;
            service.ServiceTitle=s.ServiceTitle;
            service.ServiceIcon = s.ServiceIcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}