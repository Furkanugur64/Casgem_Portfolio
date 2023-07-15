using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {         
            //var liste=db.TblJob.Select(x=>x.Name).FirstOrDefault();
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFeature()
        {

            ViewBag.featureTitle = db.TblFeature.Select(x => x.FeatureTitle).FirstOrDefault();
            ViewBag.featureDescription = db.TblFeature.Select(x => x.FeatureDescription).FirstOrDefault();
            ViewBag.featureImage = db.TblFeature.Select(x => x.FeatureImageURL).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult MyResume()
        {
            var values = db.TblResume.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialStatistic()
        {
            ViewBag.totalService = db.TblService.Count();
            ViewBag.totalMessage = db.TblMessage.Count();
            ViewBag.totalThanksMessage = db.TblMessage.Where(x => x.MessageSubject == "Teşekkür").Count();
            ViewBag.happyCustomer = 12;
            

            return PartialView();
        }

        public PartialViewResult PartialWhoami()
        {
            var info = db.TblInformation.FirstOrDefault();
            return PartialView(info);

        }

        public PartialViewResult PartialServices()
        {
            var services = db.TblService.ToList();
            return PartialView(services);

        }

        public PartialViewResult PartialReferences()
        {
            var references = db.TblReference.ToList();
            return PartialView(references);

        }

        public PartialViewResult PartialAbout()
        {
            return PartialView();

        }

        public PartialViewResult PartialIframe()
        {
            return PartialView();

        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}