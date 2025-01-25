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
        public DbSet<Product> Products { get; set; }


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

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = Guid.Parse("6da3390d-045c-466f-a721-c208151a0457"),
                Title = "Fortune of Time",
                Author = "Billy Spark",
                Description = "ss",
                ISBN = "SWD9999001",
                Price = 90,
                CategoryId = Guid.Parse("8ec37b41-9c77-4311-8463-ac8d8820cb19")
            },
            new Product
            {
                Id = Guid.Parse("766671fc-ef63-4100-abbf-0ce086a57b3b"),
                Title = "Dark Skies",
                Author = "Nancy Hoover",
                Description = "sss",
                ISBN = "CAW777777701",
                Price = 30,
                CategoryId = Guid.Parse("bc0d1735-34ef-441d-84b3-a9f8fdfa58ab")
            },
            new Product
            {
                Id = Guid.Parse("c8bf5a09-45dc-45fb-8156-e6aaf7fd237e"),
                Title = "Vanish in the Sunset",
                Author = "Julian Button",
                Description = "ss",
                ISBN = "RITO5555501",
                Price = 50,
                CategoryId = Guid.Parse("bc0d1735-34ef-441d-84b3-a9f8fdfa58ab")
            },
            new Product
            {
                Id = Guid.Parse("23818011-d27b-47d5-8d39-0083eef89022"),
                Title = "Cotton Candy",
                Author = "Abby Muscles",
                Description = "ll ",
                ISBN = "WS3333333301",
                Price = 65,
                CategoryId = Guid.Parse("f147a008-a693-4c37-b99c-379e3e89a38e")
            },
            new Product
            {
                Id = Guid.Parse("6d350160-fdfa-43cb-96c2-cd06f6c0bde6"),
                Title = "Rock in the Ocean",
                Author = "Ron Parker",
                Description = "kkk",
                ISBN = "SOTJ1111111101",
                Price = 27,
                CategoryId = Guid.Parse("f147a008-a693-4c37-b99c-379e3e89a38e")
            },
            new Product
            {
                Id = Guid.Parse("5089ecfb-17b8-4651-aca9-1036db06cee4\r\n"),
                Title = "Leaves and Wonders",
                Author = "Laura Phantom",
                Description = "oo ",
                ISBN = "FOT000000001",
                Price = 23,
                CategoryId = Guid.Parse("8ec37b41-9c77-4311-8463-ac8d8820cb19")
            });
        }


    }
}
