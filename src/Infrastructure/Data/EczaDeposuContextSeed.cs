using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class EczaDeposuContextSeed
    {
        public static async Task SeedAsync(EczaDeposuContext db)
        {
            await db.Database.MigrateAsync();

            if (await db.Medicines.AnyAsync())
                return;

            var m1 = new Medicine() { Name = "Parol", Description = "Ağrı ve ateş düşürücü", PictureUri = "m1.png", Price = 5.0m, Stock = 50 };
            var m2 = new Medicine() { Name = "Aspirin", Description = "Ağrı kesici", PictureUri = "m2.png", Price = 8.5m, Stock = 30 };
            var m3 = new Medicine() { Name = "Nurofen", Description = "Ağrı ve iltihap giderici", PictureUri = "m3.png", Price = 12.0m, Stock = 40 };
            var m4 = new Medicine() { Name = "Augmentin", Description = "Antibiyotik", PictureUri = "m4.png", Price = 25.5m, Stock = 20 };
            var m5 = new Medicine() { Name = "Panadol", Description = "Ağrı kesici ve ateş düşürücü", PictureUri = "m5.png", Price = 6.0m, Stock = 60 };
            var m6 = new Medicine() { Name = "Ibuprofen", Description = "Ağrı ve iltihap giderici", PictureUri = "m6.png", Price = 10.0m, Stock = 35 };
            var m7 = new Medicine() { Name = "Voltaren", Description = "Ağrı ve iltihap giderici", PictureUri = "m7.png", Price = 15.0m, Stock = 25 };
            var m8 = new Medicine() { Name = "Zyrtec", Description = "Alerji ilacı", PictureUri = "m8.png", Price = 18.0m, Stock = 15 };
            var m9 = new Medicine() { Name = "Rennie", Description = "Mide ilacı", PictureUri = "m9.png", Price = 9.0m, Stock = 50 };
            var m10 = new Medicine() { Name = "Daleron", Description = "Ağrı kesici ve ateş düşürücü", PictureUri = "m10.png", Price = 7.0m, Stock = 45 };
            var m11 = new Medicine() { Name = "Advil", Description = "Ağrı ve ateş düşürücü", PictureUri = "m11.png", Price = 11.5m, Stock = 30 };
            var m12 = new Medicine() { Name = "Strepsils", Description = "Boğaz pastili", PictureUri = "m12.png", Price = 8.0m, Stock = 40 };

            var medicines = new List<Medicine> { m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12 };

            db.AddRange(medicines);
            await db.SaveChangesAsync();
        }

    }
}
