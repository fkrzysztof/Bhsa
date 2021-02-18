using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class MediaPatronage
    {
        [Key]
        public int MediaPatronageID { get; set; }
        public string Link { get; set; }
        [NotMapped]
        public IFormFile Logo { get; set; }
    }
}
