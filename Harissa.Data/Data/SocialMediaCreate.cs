using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    [NotMapped]
    public class SocialMediaCreate : SocialMedia
    {
        [NotMapped]
        [Required]
        public new IFormFile NewIcon { get; set; }
    }
}
