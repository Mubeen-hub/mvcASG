using mvcASGEmployee.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcASGEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeModel model = new EmployeeModel();
            DataTable dt = model.GetAllEmployees();
            return View("Home", dt);
        }

        public ActionResult Insert()
        {
            return View("Create");
        }

        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            EmployeeModel model = new EmployeeModel();

            if (action == "Submit")
            {
                int EmployeeID = Convert.ToInt32(frm["EmployeeID "]);
                string FirstName = frm["FirstName "];
                string LastName = frm["LastName "];
                string Gender = frm["Gender"];
                string HiredDate = frm["HiredDate"];
                string Salary = frm["Salary"];
                int status = model.InsertEmployee(EmployeeID, FirstName, LastName, Gender, HiredDate, Salary);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int EmployeeID)
        {
            EmployeeModel model = new EmployeeModel();
            DataTable dt = model.GetEmployeeByID(EmployeeID);
            return View("Edit", dt);
        }

        public ActionResult UpdateRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                EmployeeModel model = new EmployeeModel();
                int EmployeeID = Convert.ToInt32(frm["EmployeeID "]);
                string FirstName = frm["FirstName "];
                string LastName = frm["LastName "];
                string Gender = frm["Gender"];
                string HiredDate = frm["HiredDate"];
                string Salary = frm["Salary"];
                int status = model.UpdateEmployee(EmployeeID, FirstName, LastName, Gender, HiredDate, Salary);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(int EmployeeID)
        {
            EmployeeModel model = new EmployeeModel();
            model.DeleteEmployee(EmployeeID);
            return RedirectToAction("Index");
        }
    }
}