using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using Hotel.Data;
using Hotel.Helpers;

namespace Hotel.Controllers
{
    [Auth]
    public class CustomerController : BaseController
    {
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            var list = _context.Customers.OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(customer);
        }
       
        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
       
            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }
          



            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;

            if (ModelState.IsValid)
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

         
            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);

            if (user.Group.Name == "Restorant")

            {

                return HttpNotFound();
            }
            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}