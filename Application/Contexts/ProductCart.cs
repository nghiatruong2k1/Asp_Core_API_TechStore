using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public class ProductCart
    {
        public int Id { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
