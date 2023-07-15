using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class StatisticController : Controller
    {

        CasgemPortfolioEntities db = new CasgemPortfolioEntities();

        public ActionResult Index()
        {
            ViewBag.EmployeeCount = db.TblEmployee.Count();
            var salary = db.TblEmployee.Max(x => x.EmployeeSalary);
            ViewBag.maxSalaryEmployee = db.TblEmployee.Where(x => x.EmployeeSalary == salary).Select(y => y.EmployeeName + " " + y.EmployeeSurname).FirstOrDefault();

            ViewBag.totalCityCount = db.TblEmployee.Select(x=>x.EmployeeCity).Distinct().Count();

            ViewBag.avgEmployeeSalary = db.TblEmployee.Average(x => x.EmployeeSalary);


            ViewBag.countSoftwareDepartment = db.TblEmployee.Where(x => x.EmployeeDepartment == db.TblDepartment.Where(z => z.DepartmentName == "Yazılım").Select(y => y.DepatmentID).FirstOrDefault()).Count();

            ViewBag.TotalSalary = db.TblEmployee.Where(x => x.EmployeeCity == "Adana" || x.EmployeeCity == "Ankara").Sum(x => x.EmployeeSalary);

            var departmantID=db.TblDepartment.Where(x=>x.DepartmentName=="Yazılım").Select(x=>x.DepatmentID).FirstOrDefault();
            ViewBag.sumSalaryFromSoftwareDepartment = db.TblEmployee.Where(x=>x.EmployeeCity == "Ankara" && x.EmployeeDepartment==departmantID).Sum(x => x.EmployeeSalary);
            return View();
        }
    }
}