using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaviscaAssessment.Models
{
    public class Order : Entity
    {
        public string OrderStatus { get; set; }

        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
