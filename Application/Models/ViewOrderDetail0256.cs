using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class ViewOrderDetail0256
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string TypeName { get; set; }
        public decimal? Rating { get; set; }
    }
}
