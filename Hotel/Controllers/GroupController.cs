using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Data;
using Hotel.Helpers;
using Hotel.Models;

namespace Hotel.Controllers
{
    [Auth]
    public class GroupController : BaseController
    {
        // GET: Group
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name != "Admin")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            var list = _context.Groups.OrderByDescending(g => g.Id).ToList();
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
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Group group)
        {

            if (ModelState.IsValid)
            {
                _context.Groups.Add(group);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            return View(group);
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
            Group group = _context.Groups.Find(id);

            if (group == null)
            {
                return HttpNotFound();
            }

            ViewBag.Groups = _context.Groups.ToList();
            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(Group grp)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(grp).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(grp);

        }


        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name != "Admin")

            {

                return HttpNotFound();

            }
            Group grp = _context.Groups.Find(id);

            if (grp == null)
            {
                return HttpNotFound();
            }

            _context.Groups.Remove(grp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}