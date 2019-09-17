using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Data;
using Hotel.Models;

using Hotel.Helpers;

namespace Hotel.Controllers
{
    [Auth]
    public class BedTypeController : BaseController
    {
        // GET: BedType
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name != "Admin")

            {


                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            var list = _context.BedTypes.OrderByDescending(c => c.Id).ToList();
            return View(list);
          


        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name != "Admin")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            ViewBag.BedTypes = _context.BedTypes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(BedType BedType)
        {

            if (ModelState.IsValid)
            {
                _context.BedTypes.Add(BedType);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            return View(BedType);
        }

        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name != "Admin")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            BedType BedType = _context.BedTypes.Find(id);

            if (BedType == null)
            {
                return HttpNotFound();
            }

            ViewBag.BedTypes = _context.BedTypes.ToList();
            return View(BedType);
        }

        [HttpPost]
        public ActionResult Edit(BedType BedType)
        {

            if (ModelState.IsValid)
            {
                _context.Entry(BedType).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(c => c.Name).ToList();

            return View(BedType);
        }

        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name != "Admin")
            {
                return HttpNotFound();
            }
            BedType BedType = _context.BedTypes.Find(id);

            if (BedType == null)
            {
                return HttpNotFound();
            }

            _context.BedTypes.Remove(BedType);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}