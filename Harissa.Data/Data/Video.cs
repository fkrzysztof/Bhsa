using System.ComponentModel.DataAnnotations;

namespace Harissa.Data.Data
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [DataType(DataType.Url)]
        [RegularExpression(".*(youtube.com|https://youtu.be).*")]
        [Required]
        public string Link { get; set; }
        public int Index { get; set; }
    }
}
