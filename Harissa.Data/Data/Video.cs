using System.ComponentModel.DataAnnotations;

namespace Harissa.Data.Data
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [DataType(DataType.ImageUrl)]
        [Required]
        public string Link { get; set; }
    }
}
