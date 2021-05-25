using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string MediaItem { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DateOfPublication { get; set; }
        [NotMapped]
        public IFormFile FormFileItem { get; set; }

        public ICollection<NewsMediaCollection> NewsMediaCollections  { get; set; }


    }
}
