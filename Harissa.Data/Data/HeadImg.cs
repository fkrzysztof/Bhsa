using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class HeadImg
    {
        public int HeadImgID { get; set; }
        public string HeadMediaItem { get; set; }
        public int PageSettingsID { get; set; }
        [ForeignKey("PageSettingsID")]
        public PageSettings PageSettings { get; set; }
    }
}
