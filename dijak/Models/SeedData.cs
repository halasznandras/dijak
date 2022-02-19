using dijak.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dijak.Models
{
    public class SeedData
    {
        public static void Inicializalas(IServiceProvider serviceProvider)
        {
            ApplicationDbContext db = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            if (!db.NobelDij.Any())
            {
                var sorok = File.ReadAllLines(@"C:\temp\nobel.csv").Skip(1);
                foreach (var sor in sorok)
                {
                    db.NobelDij.Add(new NobelDij(sor));
                }
                db.SaveChanges();
            }
        }
    }
}
