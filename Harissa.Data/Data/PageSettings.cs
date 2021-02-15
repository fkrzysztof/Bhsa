using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class PageSettings
    {
        [Key]
        public int PageSettingsID { get; set; }
        public string NoPicture { get; set; }
        public ICollection<SocialMedia> socialMedias { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Pick an Image")]
       // [FileExtensions("jpg",ErrorMessage = "dodaj plik")]
        public IFormFile NewFile { get; set; }
    }
}
