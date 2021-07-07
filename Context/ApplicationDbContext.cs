using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaviscaAssessment.Models;

namespace TaviscaAssessment.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<PizzaType> PizzaType { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<PizzaIngredient> PizzaIngredient { get; set; }

        public async new Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here   

            modelBuilder.Entity<PizzaType>()
                   .HasData(
                     new PizzaType { Id = 1, TypeName = "Margherita", PizzaImage = ""},
                     new PizzaType { Id = 2, TypeName = "Peppy Paneer", PizzaImage = "" },
                     new PizzaType { Id = 3, TypeName = "Mexican Green Wave", PizzaImage = "" },
                     new PizzaType { Id = 4, TypeName = "CHEESE N CORN", PizzaImage = "" }
                   );

            modelBuilder.Entity<Ingredients>()
                   .HasData(
                     new Ingredients { Id = 1, Name = "Dough/Flour", Price = 10, Image = "" },
                     new Ingredients { Id = 2, Name = "Pizza Dough Mix", Price = 20, Image = "" },
                     new Ingredients { Id = 3, Name = "Deep Dish Pizza Dough Mix", Price = 30, Image = "" },
                     new Ingredients { Id = 4, Name = "Ultra Thin/Low Carb Pizza Dough", Price = 40, Image = "" },
                     new Ingredients { Id = 5, Name = "Gluten Free Pizza Crust", Price = 50, Image = "" },
                     new Ingredients { Id = 6, Name = "Pizza Sauce", Price = 80, Image = "" },
                     new Ingredients { Id = 7, Name = "Pizza Sauce Seasoning", Price = 80, Image = "" }
                   );

        }

    }
}
