using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaviscaAssessment.Models;

namespace TaviscaAssessment.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Ingredients> Ingredients { get; set; }
        DbSet<PizzaType> PizzaType { get; set; }
        DbSet<Pizza> Pizza { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<PizzaIngredient> PizzaIngredient { get; set; }
        Task<int> SaveChanges();

    }
}