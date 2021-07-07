using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaviscaAssessment.Models
{
    public class PizzaIngredient : Entity
    {
        public int PizzaTypeId { get; set; }
        public int IngredientId { get; set; }
        public virtual Ingredients Ingredients { get; set; }
    }
}
