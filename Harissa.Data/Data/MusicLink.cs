using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Harissa.Data.Data
{
    public class MusicLink
    {
        [Key]
        public int MusicLinkID { get; set; }
        [Required]
        public string LinkToAlbum { get; set; }

        public int MusicPlatformID { get; set; }
        [ForeignKey("MusicPlatformID")]
        public MusicPlatform MusicPlatform { get; set; }
        public int MusicID { get; set; }
        [ForeignKey("MusicID")]
        public Music Music { get; set; }
    }
}
