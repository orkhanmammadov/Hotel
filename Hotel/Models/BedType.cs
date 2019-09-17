using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class BedType
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Yataq adı Boş ola bilməz"),MaxLength(50,ErrorMessage ="Yataq Adı Max 50 Xarakter ola bilər")]
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}