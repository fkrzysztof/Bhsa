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
        public ICollection<SocialMedia> socialMedias { get; set; }
        public string NoPicture { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        [Required]
        public IFormFile NoPictureNewFile { get; set; }
        public PrivacyPolicy privacyPolicy { get; set; }
        public string Logo { get; set; }
        [NotMapped]
        [Display(Name = "Image")]
        [Required]
        public IFormFile LogoNewFile { get; set; }
        [DataType(DataType.Url)]
        [RegularExpression(".*(youtube.com|https://youtu.be).*")]
        public string IframeVideo { get; set; }
        public string IframeTitle { get; set; }
        public string IframeText { get; set; }
        public string HeaderText { get; set; }
        public ICollection<HeadImg> HeadImgs { get; set; }
        public ICollection<FooterImg> FooterImgs { get; set; }
    }
}
