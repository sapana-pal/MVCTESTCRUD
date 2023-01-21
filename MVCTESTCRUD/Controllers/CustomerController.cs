using MVCTESTCRUD.DataAccess;
using MVCTESTCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTESTCRUD.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer objCustomer)
        {

            objCustomer.date = Convert.ToDateTime(objCustomer.date);
            if (ModelState.IsValid) 
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                TempData["result1"] = result;
                ModelState.Clear();   
                return RedirectToAction("ShowAllCustomerDetails");
            }

            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }
        public ActionResult AllActiveData(string Active)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            return View(objDB.SelectAllActiveData(Active));
        }
        [HttpGet]
        public ActionResult Details(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); 
            return View(objDB.SelectDatabyID(ID));
        }
        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); 
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.date = Convert.ToDateTime(objCustomer.date);
            if (ModelState.IsValid) 
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.UpdateData(objCustomer);
                TempData["result2"] = result;
                ModelState.Clear(); 
                return RedirectToAction("ShowAllCustomerDetails");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear();     
            return RedirectToAction("ShowAllCustomerDetails");
        }
    }
}
