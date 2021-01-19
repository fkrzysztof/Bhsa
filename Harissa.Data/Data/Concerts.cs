using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Harissa.Data.Data
{
    public class Concerts
    {
        [Key]
        public int ConcertsID { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

    }
}
