﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaviscaAssessment.Models
{
    public class Ingredients : Entity
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        public ICollection<PizzaIngredient> PizzaIngredient { get; set; }
    }
}
