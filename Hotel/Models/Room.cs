using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Otaq Nömrəsi boş ola bilməz")]
          [Display(Name ="Otaq Nömrəsi")]
        public int Number { get; set; }

        public bool Status { get; set; }
        [Required(ErrorMessage = "Qiymət boş ola bilməz")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Böyük Kapasitəsi boş ola bilməz")]
        [Display(Name ="Böyük Kapasitesi")]
        public int AdultCapacity { get; set; }
        [Required(ErrorMessage = "Uşaq Kapasitesi boş ola bilməz")]
        [Display(Name = "Uşaq Kapasitesi")]
        public int ChildCapacity { get; set; }
        [Display(Name = "Yataq Tipi")]
        public int BedTypeId { get; set; }
        public BedType BedType { get; set; }
        [Required(ErrorMessage = "Otaq Haqqında Məlumat Boş ola bilməz"), MaxLength(500,ErrorMessage ="Otaq Haqqında Məlumat Max 500 xarakter ola bilər")]
        public string Description { get; set; }

        public string Photo { get; set; }

        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        public List<Booking> Bookings { get; set; }
        public List<RestorantPrice> RestorantPrices { get; set; }



    }
}