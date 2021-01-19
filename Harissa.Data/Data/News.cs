using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
