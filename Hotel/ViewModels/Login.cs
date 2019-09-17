using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class Login
    {
        [Display(Name = "E-poçt")]
        [Required(ErrorMessage = "E-poçt boş ola bilməz"), MaxLength(50, ErrorMessage = "Email Max 50 xarakter ola bilər")]
        public string Email { get; set; }


        [Display(Name = "Şifrə")]
        [Required(ErrorMessage = "Şifrə boş ola bilməz"), MaxLength(100, ErrorMessage = "Şifrə 50 xarakter ola bilər")]
        public string Password { get; set; }
    }
}