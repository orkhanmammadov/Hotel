using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Hotel.Helpers
{
    public class FileManager
    {
        public static string Upload(HttpPostedFileBase File)

        {

            var text = File.FileName.Split('.');

            var filename = Guid.NewGuid().ToString() + "." + text[text.Length - 1];

            string path = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads"), filename);



            File.SaveAs(path);



            return filename;

        }



        public static void Delete(string File)

        {

            string path = Path.Combine(HttpContext.Current.Server.MapPath("/Uploads"), File);



            if (System.IO.File.Exists(path))

            {

                System.IO.File.Delete(path);

            }

        }
    }
}