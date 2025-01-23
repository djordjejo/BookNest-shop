using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDB : DbContext
    {
        private readonly DbContextOptions<ApplicationDB> dbContext;

        public DbSet<Category> Categories { get; set; }
        public ApplicationDB(DbContextOptions <ApplicationDB> dbContext):base(dbContext)
        {
            dbContext = dbContext;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Category>().HasData(
                new Category {
                    Id = Guid.Parse("bc0d1735-34ef-441d-84b3-a9f8fdfa58ab"),
                    Name = "Comedy",
                    Description = "Smesne knjige"
                },
                new Category
                {
                    Id = Guid.Parse("f147a008-a693-4c37-b99c-379e3e89a38e"),
                    Name = "Akcioni",
                    Description = "Knjige koje imaju pouno uzbudljivih dogadjaja"
                },
                new Category
                {
                    Id = Guid.Parse("8ec37b41-9c77-4311-8463-ac8d8820cb19"),
                    Name = "Trejler",
                    Description = "Knjige u kojima je prica neizvesna"
                });



        }

        
    }
}
