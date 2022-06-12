using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class OrderDetail0256
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
    }
}
