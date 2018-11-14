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
                context.SaveChanges();
            }
        }
    }
}