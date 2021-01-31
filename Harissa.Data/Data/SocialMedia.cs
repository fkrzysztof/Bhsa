using System.ComponentModel.DataAnnotations;

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
    }
}
