using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class ViewOrder0256
    {
        public int? Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? VoucherSale { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
        public int? UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public string Location { get; set; }
        public long? TotalPrice { get; set; }
    }
}
