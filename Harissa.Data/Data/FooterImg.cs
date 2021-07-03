using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class FooterImg
    {
        public int FooterImgID { get; set; }
        public string FooterImgItem { get; set; }
        public int PageSettingsID { get; set; }
        [ForeignKey("PageSettingsID")]
        public PageSettings PageSettings { get; set; }
    }
}
