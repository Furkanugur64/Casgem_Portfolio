﻿using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class MessageController : Controller
    {

        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            var values= db.TblMessage.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var message= db.TblMessage.Find(id);
            db.TblMessage.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MessageDetails(int id)
        {
            var value=db.TblMessage.Find(id);
            return View(value);
        }
    }
}