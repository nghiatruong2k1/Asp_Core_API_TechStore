using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contexts
{
    public class Carts
    {
        public List<ProductCart> Products { get; set; }
        public OrderVoucher0256 Voucher { get; set; }
    }
}
