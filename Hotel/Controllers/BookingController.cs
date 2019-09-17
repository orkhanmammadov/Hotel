using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Data;
using Hotel.Models;
using Hotel.ViewModels;
using Hotel.Helpers;



namespace Hotel.Controllers
{
    [Auth]
    public class BookingController : BaseController
    {

       
     
       
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;
            var list = _context.Bookings.Include("Room").Include("Customer").Include("User").ToList();

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
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();

            return View();
        }


       
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = userrm;


            if (ModelState.IsValid)
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();

            return View(booking);
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
            Booking booking = _context.Bookings.Find(id);

            if (booking == null)
            {
                return HttpNotFound();
            }

            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();

            return View(booking);

        }
        public ActionResult Search(SearchRoomBooking search)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            if (user.Group.Name == "Restorant")

            {

                return RedirectToAction("index", "free");

            }
            ViewBag.User = user;


            List<Room> rooms = _context.Rooms.Include("Bookings").Where(r => (search.Adult != -1 ? r.AdultCapacity == search.Adult : true)
            &&r.Status==true && r.ChildCapacity == search.Child).ToList();

            return View(rooms);

        }





        [HttpPost]
        public ActionResult Edit(Booking bkg)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User userrm = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = userrm;

            if (ModelState.IsValid)
            {
                _context.Entry(bkg).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            ViewBag.Rooms = _context.Rooms.OrderBy(r => r.Number).ToList();
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Fullname).ToList();
            ViewBag.Menus = _context.Menus.OrderBy(m => m.Name).ToList();
            ViewBag.Users = _context.Users.OrderBy(u => u.FullName).ToList();

            return View(bkg);

        }
    }
}