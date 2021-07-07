using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaviscaAssessment.Models
{
    public class Pizza : Entity
    {
        public int TotalCost { get; set; }

        public int PizaaTypeId { get; set; }

        public string Ingredients { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
