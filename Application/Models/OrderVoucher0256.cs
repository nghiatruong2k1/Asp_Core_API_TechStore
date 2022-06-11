using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class OrderVoucher0256
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDes { get; set; }
        public string Code { get; set; }
        public int? Value { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
    }
}
