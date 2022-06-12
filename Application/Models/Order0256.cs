using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class Order0256
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? VoucherSale { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
        public int? StatusId { get; set; }
    }
}
