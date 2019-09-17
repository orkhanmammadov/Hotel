using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kategoriya Adı Boş ola bilməz"), MaxLength(50,ErrorMessage ="Kategoriya Adi Max 50 xarakter ola bilər")]
        public string Name { get; set; }
        public List<Menu> Menus { get; set; }



    }
}