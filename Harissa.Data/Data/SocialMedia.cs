using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    public class SocialMedia
    {
        [Key]
        public int SocialMediaID { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string Link { get; set; }        
        public string Icon { get; set; }
        
        public int PageSettingsID { get; set; }
        [ForeignKey("PageSettingsID")]
        public PageSettings pageSettings { get; set; }
    }
}
