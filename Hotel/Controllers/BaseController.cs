using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public readonly HotelContext _context;

        public BaseController()
        {
            _context = new HotelContext();
        }
    }
}