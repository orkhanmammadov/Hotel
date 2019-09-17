using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;
using Hotel.Helpers;
using Hotel.Data;


namespace Hotel.Controllers
{
    [Auth]
    public class RoomController : BaseController
    {
        // GET: Room
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            var list = _context.Rooms.Include("BedType").OrderByDescending(r => r.Id).ToList();
            return View(list);
        }

        public ActionResult Create()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;

            if (room.File.ContentLength / 1024 / 1024 > 5)
            {
                ModelState.AddModelError("Şəkil", "Maksimum 5mb Şəkil Yükləyə Bilərsiniz");
            }

            if (ModelState.IsValid)
            {
                room.Photo = FileManager.Upload(room.File);
                room.Status = true;
                _context.Rooms.Add(room);
                _context.SaveChanges();

                return RedirectToAction("index");
            }


            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();

            return View(room);
        }

        public ActionResult Edit(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            Room room = _context.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();

            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View(room);
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if (room.File != null)
            {
                if (room.File.ContentLength / 1024 / 1024 > 5)
                {
                    ModelState.AddModelError("Şəkil", "Maksimum 5mb Şəkil Yükləyə Bilərsiniz");
                }
            }

            if (ModelState.IsValid)
            {
                if (room.File != null)
                {
                    FileManager.Delete(room.Photo);
                    room.Photo = FileManager.Upload(room.File);
                }

                _context.Entry(room).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");

            }

            ViewBag.BedTypes = _context.BedTypes.OrderBy(b => b.Name).ToList();
            return View(room);
        }

        public ActionResult Delete(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Restorant")

            {

                return HttpNotFound();

            }
            Room room = _context.Rooms.Find(id);

            if (room == null)
            {
                return HttpNotFound();
            }

            if (room.File != null)
            {
                FileManager.Delete(room.Photo);

            }

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}