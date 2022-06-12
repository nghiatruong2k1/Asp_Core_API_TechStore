using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class ProductRating0256
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? Vote { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
        public string FullDes { get; set; }
    }
}
