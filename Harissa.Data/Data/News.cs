using System;
using System.ComponentModel.DataAnnotations;

namespace Harissa.Data.Data
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string MediaItem { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime DateOfPublication { get; set; }
    }
}
