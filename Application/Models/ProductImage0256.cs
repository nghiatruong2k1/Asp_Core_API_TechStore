using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class ProductImage0256
    {
        public int Id { get; set; }
        public string Alt { get; set; }
        public int? ProductId { get; set; }
        public int? ImageId { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
    }
}
