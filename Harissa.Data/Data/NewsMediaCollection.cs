using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class NewsMediaCollection
    {
        public int NewsMediaCollectionID { get; set; }
        public string MediaItem { get; set; }
        public int NewsID { get; set; }
        [ForeignKey("NewsID")]
        public News News { get; set; }
    }
}