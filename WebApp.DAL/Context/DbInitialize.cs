using Microsoft.EntityFrameworkCore.Internal;
using WebApp.DAL.Entities;

namespace WebApp.DAL.Context
{
    public static class DbInitialize
    {
        public static void Seed(MobileContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Phones.Any())
            {
                context.Phones.Add(new Phone {Name = "Nokia", Price = 100});
                context.Phones.Add(new Phone {Name = "Samsung", Price = 200});
                context.Phones.Add(new Phone {Name = "Huawei", Price = 170});
                context.Phones.Add(new Phone {Name = "Xiomi", Price = 190});
                context.Phones.Add(new Phone {Name = "Lg", Price = 130});
                context.Phones.Add(new Phone {Name = "Apple", Price = 230});
                context.Phones.Add(new Phone {Name = "Google", Price = 175});
                context.Phones.Add(new Phone {Name = "Sony", Price = 95});
                context.Phones.Add(new Phone {Name = "Honor", Price = 75});
                context.Phones.Add(new Phone {Name = "Motorola", Price = 120});
                context.Phones.Add(new Phone {Name = "CAT", Price = 130});
                context.Phones.Add(new Phone {Name = "BlackBerry", Price = 140});
                context.Phones.Add(new Phone {Name = "Alcatel", Price = 180});
                context.Phones.Add(new Phone {Name = "Acer", Price = 100});
                context.SaveChanges();
            }
        }
    }
}