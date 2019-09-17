using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class RestorantPrice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Otaq Nömrəsi")]
        [Display(Name = "Otaq Nömrəsi")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Yemək Adı Boş ola bilməz")]
        [Display(Name = "Yemək Adı")]
        public int MenuId { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public Room Room { get; set; }
        public Menu Menu { get;set; }
    }
}