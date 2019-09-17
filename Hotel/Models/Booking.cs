using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Display(Name ="İstifadəçi")]
        public int UserId { get; set; }
        [Display(Name = "Müştəri")]
        public int CustomerId { get; set; }
        [Display(Name = "Giriş")]
        public DateTime CheckIn { get; set; }
        [Display(Name = "Çıxış")]
         public DateTime CheckOut { get; set; }
        [ Display(Name = "Otaq Nömrəsi")]
        public int RoomId { get; set; }
          public bool Status { get; set; }
           public Room Room { get; set; }
        public Customer Customer { get; set; }
        public User User { get; set; }



    }
}