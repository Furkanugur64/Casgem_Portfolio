using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class WhoamiController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblInformation.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateInformation(int id)
        {
            var info=db.TblInformation.Find(id);
            return View(info);
        }

        [HttpPost]
        public ActionResult UpdateInformation(TblInformation information)
        {
            var info = db.TblInformation.Find(information.İnformationID);
            info.İnformationTitle = information.İnformationTitle;
            info.İnformationContent = information.İnformationContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}