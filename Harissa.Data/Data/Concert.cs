using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    public class Concert
    {
        [Key]
        public int ConcertID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        [NotMapped]
        public IFormFile FormFileItem { get; set; }
        public string MediaItem { get; set; }
    }
}
