using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    public class MusicPlatform
    {
        public int MusicPlatformID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
        [NotMapped]
        public IFormFile NewIcon { get; set; }
        public ICollection<MusicLink> MusicLinks { get; set; }
    }
}
