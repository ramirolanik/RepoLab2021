
using ProyectoMVC.Entities;
using ProyectoMVC.Logic;
using ProyectoMVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoMVC.MVC.Controllers
{
    public class CustomersController : Controller
    {
        CustomersLogic logic = new CustomersLogic();
        // GET: Customers
        public ActionResult Index()
        {
            
            List<Entities.Customers> customers = logic.GetAll();

            List<CustomerView> customerViews = customers.Select(s => new CustomerView
            {
                id = s.CustomerID,
                ContactName = s.ContactName,
                CompanyName = s.CompanyName
            }).ToList();
            return View(customerViews);
        }
        public ActionResult Insert()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Insert(CustomerView customerView)
        {
            try
            {
                Customers customerEntity = new Customers { ContactName = customerView.ContactName }; 

                logic.Add(customerEntity);

            return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }

        }

        public ActionResult Delete(string id)
        {
            logic.Delete(id);
            return RedirectToAction("Index");
        }
    }

}