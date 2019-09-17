using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Group
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Qrup Adı Boş ola Bilməz"), MaxLength(50, ErrorMessage = "Qrup Adı Max 50 xarakter ola bilər")]
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}