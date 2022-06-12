using System;
using System.Collections.Generic;

#nullable disable

namespace Application.Models
{
    public partial class Image0256
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Url { get; set; }
        public int? Size { get; set; }
        public bool? IsPublic { get; set; }
        public bool? IsTrash { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
