using Employee.EmployeeCardRef;
using Employee.Functions;
using Employee.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {

            return View(Helpers.GetEmployees());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateViewModel create)
        {
            EmployeeCard card = new EmployeeCard();
            card.First_Name = create.FirstName;
            card.Last_Name = create.LastName;
            card.E_Mail = create.Email;
            card.PIN_Number = create.PinNumber;
            card.Bank_Account_No = create.AccountNo;

            Helpers.CreateEmployee(card);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update( string DocumentNo)
                   {
            return View(Helpers.GetEmployee(DocumentNo)
                );
        }
        [HttpPost]
        public ActionResult Update ( string DocumentNo, EmployeeCard update)
        {
             EmployeeCard card = Helpers.GetEmployee(DocumentNo);
            card.First_Name = update.First_Name;
            card.Last_Name = update.Last_Name;
            card.Middle_Name = update.Middle_Name;
            card.Initials=update.Initials;
            card.Gender = update.Gender;
            card.Company_E_Mail = update.Company_E_Mail;
            card.Section_Unit = update.Section_Unit;

            Helpers.UpdateEmployee(update);

            return View();
        }
        [HttpGet]
        public ActionResult Details( string DocumentNo)
         {
            return View(Helpers.GetEmployee(DocumentNo));
        }
        [HttpPost]
        public ActionResult details ( string DocumentNo, EmployeeCard details)
        {
             EmployeeCard card = Helpers.GetEmployee(DocumentNo);
            card.First_Name = details.First_Name;
            card.Last_Name = details.Last_Name;
            card.Middle_Name = details.Middle_Name;
            card.Initials=details.Initials;
            card.Gender = details.Gender; 
            card.Company_E_Mail = details.Company_E_Mail;
            card.Section_Unit = details.Section_Unit;
                
            Helpers.GetEmployee(DocumentNo);

            return View();
        }

        [HttpGet]
        public ActionResult Delete( string key )

        {
             Helpers.DeleteEmployee(key);

            return RedirectToAction("Index");                                                                                                             
        }
      










    }
}