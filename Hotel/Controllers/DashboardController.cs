
using Hotel.Helpers;
using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Hotel.Controllers
{
    [Auth]
    public class DashboardController : BaseController
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            List<Booking> list = _context.Bookings.Include("Room").Include("Customer").ToList();

            return View(list);
        }

        public ActionResult CheckOut(int id)
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
    
           
            ViewBag.User = user;
            return View();
        }

       

    }
}