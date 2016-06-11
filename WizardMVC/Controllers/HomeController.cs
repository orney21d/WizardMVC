using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WizardMVC.Models;

namespace WizardMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("BasicDetails");
        }

        private Customer GetCustomer()
        {
            if (Session["customer"] == null)
            {
                Session["customer"] = new Customer();
            }
            return (Customer)Session["customer"];
        }

        private void RemoveCustomer()
        {
            Session.Remove("customer");
        }

        [HttpPost]
        public ActionResult BasicDetails(BasicDetails data, string prevBtn, string nextBtn)
        {
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    Customer obj = GetCustomer();
                    obj.CustomerID = data.CustomerID;
                    obj.CompanyName = data.CompanyName;
                    return View("AddressDetails");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddressDetails(AddressDetails data, string prevBtn, string nextBtn)
        {
            Customer obj = GetCustomer();
            if (prevBtn != null)
            {
                BasicDetails bd = new BasicDetails();
                bd.CustomerID = obj.CustomerID;
                bd.CompanyName = obj.CompanyName;
                return View("BasicDetails", bd);
            }
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.Address = data.Address;
                    obj.City = data.City;
                    obj.Country = data.Country;
                    obj.PostalCode = data.PostalCode;
                    return View("ContactDetails");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult ContactDetails(ContactDetails data,
string prevBtn, string nextBtn)
        {
            Customer obj = GetCustomer();
            if (prevBtn != null)
            {
                AddressDetails ad = new AddressDetails();
                ad.Address = obj.Address;
                ad.City = obj.City;
                ad.Country = obj.Country;
                ad.PostalCode = obj.PostalCode;
                return View("AddressDetails", ad);
            }
            if (nextBtn != null)
            {
                if (ModelState.IsValid)
                {
                    obj.ContactName = data.ContactName;
                    obj.Phone = data.Phone;
                    obj.Fax = data.Fax;
                    WizardMVCEntities db = new WizardMVCEntities();
                    db.Customers.Add(obj);
                    db.SaveChanges();
                    RemoveCustomer();
                    return View("Success");
                }
            }
            return View();
        }
    }
}