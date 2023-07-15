using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Casgem_Portfolio.Controllers
{
    public class LoginController : Controller
    {
        CasgemPortfolioEntities entities = new CasgemPortfolioEntities();

        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TblAdmin admin)
        {
            var admininfo = entities.TblAdmin.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.UserName, false);
                Session["username"] = admininfo.UserName;
                return RedirectToAction("Index", "Whoami");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı ve/veya şifre yanlış.";
                return View("GirisYap");
            }
        }
    }
}