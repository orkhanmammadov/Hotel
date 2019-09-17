using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Yemək Adı Boş ola Bilməz"), MaxLength(50, ErrorMessage = "Yemək Adı Max 50 xarakter ola bilər")]
        [Display(Name = "Adı")]
        public string Name { get; set; }
         [Column(TypeName = "money")]
        [Display(Name = "Qiyməti")]
        public decimal Price { get; set; }
       [Display(Name="Kategoriya")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
  

        public List<Booking> Bookings { get; set; }
        public List<RestorantPrice> RestorantPrices { get; set; }
    }
}