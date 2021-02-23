using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class PrivacyPolicy
    {
        public int PrivacyPolicyID { get; set; }
        public string Text { get; set; }
        public int PageSettingsID { get; set; }
        [ForeignKey("PageSettingsID")]
        public PageSettings pageSettings { get; set; }
    }
}
