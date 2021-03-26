using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    public class Music
    {
        [Key]
        public int MusicID { get; set; }
        [DataType(DataType.Html)]
        [Required]
        public string IFrame { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int DateOfPublication { get; set; }
        [NotMapped]
        public  IFormFile NewCover { get; set; }
        public string Cover { get; set; }
        public ICollection<MusicLink> MusicLinks { get; set; }
    }
}





   