using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad və soyad boş ola bilməz"),MaxLength(50, ErrorMessage = "Ad və soyad Max 50 xarakter ola bilər")]
        [Display(Name ="Ad və soyad")]
        public string FullName { get; set; }
        [Display(Name = "E-poçt")]
        [Required(ErrorMessage = "Email boş ola bilməz"), MaxLength(50, ErrorMessage = "Email Max 50 xarakter ola bilər")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifrə boş ola bilməz"), MaxLength(100, ErrorMessage = "Istifadəçi Adı 50 xarakter ola bilər")]
        [Display(Name = "Şifrə")]
        public string Password { get; set; }
        [Display(Name = "Vəzifəsi")]
        public int GroupId { get; set; }
        public string token { get; set; }

        public Group Group { get; set; }

        public List<Booking> Bookings { get; set; }


    }
}