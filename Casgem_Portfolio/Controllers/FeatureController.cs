using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class FeatureController : Controller
    {
        CasgemPortfolioEntities entities= new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            //entities.TblFeature.ToList();
            return View();
        }
    }
}