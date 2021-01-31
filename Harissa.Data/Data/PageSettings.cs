using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Harissa.Data.Data
{
    public class PageSettings
    {
        [Key]
        public int PageSettingsID { get; set; }
        [Required]
        public string NoPicture { get; set; }
        public ICollection<SocialMedia> socialMedias { get; set; }
    }
}
