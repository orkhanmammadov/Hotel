using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad və Soyad Boş ola bilməz"), MaxLength(100, ErrorMessage = "Ad və Soyad Max 100 xarakter ola bilər")]
        [Display(Name = "Ad və Soyad")]
        public string Fullname { get; set; }
        [Display(Name = "Müştəri Tipi")]
       public bool isAdult { get; set; }
    }
}