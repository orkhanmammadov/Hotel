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
    public class FreeController : BaseController
    {
        // GET: Free
        public ActionResult Index()
        {
            string cookie = Request.Cookies["cookie"].Value.ToString();
            User user = _context.Users.Include("Group").FirstOrDefault(u => u.token == cookie);
            ViewBag.User = user;
            var list = _context.BedTypes.OrderByDescending(c => c.Id).ToList();
            return View(list);
          
        }
    }
}