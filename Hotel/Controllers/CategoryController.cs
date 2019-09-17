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
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Reseption")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            var list = _context.Categories.OrderByDescending(c => c.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Reseption")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            return View(category);
        }

        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Reseption")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            Category category = _context.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.Categories = _context.Categories.OrderBy(c => c.Name).ToList();

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Reseption")

            {

                return HttpNotFound();

            }
            Category category = _context.Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}