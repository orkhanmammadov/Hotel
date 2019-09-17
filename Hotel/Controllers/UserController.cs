using Hotel.Helpers;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    [Auth]
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name != "Admin")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            var list = _context.Users.Include("Group").OrderByDescending(u => u.Id).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name != "Admin")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            ViewBag.Groups = _context.Groups.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = userrm;
            if (ModelState.IsValid)
            {
                user.Password = Crypto.HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("index");
            }


            return View(user);
        }


        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name != "Admin")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Groups = _context.Groups.ToList();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            ViewBag.Groups = _context.Groups.OrderBy(g => g.Name).ToList();
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name != "Admin")

            {

                return HttpNotFound();

            }
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}