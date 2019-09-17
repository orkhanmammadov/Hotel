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
    public class RestorantPriceController : BaseController
    {
        // GET: Restorant
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Reseption")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            // Status True olanlar gosterilsin edilecek
            var list = _context.RestorantPrices.Include("Room").Include("Menu").Where(s => s.Status == true).OrderByDescending(r => r.Room.Number).ToList();
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
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();

            return View();

        }
        [HttpPost]
        public ActionResult Create(RestorantPrice rstp)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = userrm;
            if (ModelState.IsValid)
            {

               
                ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();
                rstp.Status = true;
               _context.RestorantPrices.Add(rstp);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(rstp);

        }
        public ActionResult Edit(int Id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Reseption")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = userrm;
            RestorantPrice rstp = _context.RestorantPrices.Find(Id);

            if (rstp == null)
            {
                return HttpNotFound();

            }
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();

            return View(rstp);
        }
      
        [HttpPost]
        public ActionResult Edit(RestorantPrice rstp)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = userrm;
            if (ModelState.IsValid)
            {
                _context.Entry(rstp).State = System.Data.Entity.EntityState.Modified;
                rstp.Status = true;
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Room = _context.Rooms.OrderByDescending(r => r.Number).ToList();
            ViewBag.Menu = _context.Menus.OrderByDescending(r => r.Name).ToList();
            return View(rstp);

        }
        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (userrm.Group.Name == "Reseption")

            {

                return HttpNotFound();

            }
            RestorantPrice rstp = _context.RestorantPrices.Find(id);

            if (rstp == null)
            {
                return HttpNotFound();
            }

            _context.RestorantPrices.Remove(rstp);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}