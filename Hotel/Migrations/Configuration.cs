namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Helpers;
    using Hotel.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Hotel.Data.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Hotel.Data.HotelContext context)
        {

           // Group group = new Group
           // {
           //     Name = "Admin"
           // };
           // context.Groups.Add(group);
           
           // Group group1 = new Group
           // {
           //     Name = "Reseption"
           // };
           // context.Groups.Add(group1);
           // Group group2 = new Group
           // {
           //     Name = "Restorant"
           // };
           // context.Groups.Add(group2);
           // context.SaveChanges();
           // string password = "12345";
           // User user = new User
           // {
           //     FullName = "Ad soyad",
           //     Email = "yolchu@nasib.me",
           //     Password = Crypto.HashPassword(password),
           //     GroupId =1
           // };
           
           //context.Users.Add(user);
           // context.SaveChanges();

        }
    }
}
