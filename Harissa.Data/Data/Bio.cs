using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Harissa.Data.Data
{
    public class Bio
    {
        [Key]
        public int BioID { get; set; }
        public string Text { get; set; }


    }
}
