using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class Product0256
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int? Price { get; set; }
        public int? SalePrice { get; set; }
        public char? CurrencyUnit { get; set; }
        public string ShortDes { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
        public string FullDes { get; set; }
        public string Properties { get; set; }
    }
}
