using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    [NotMapped]
    public class MusicCreate : Music
    {
        [NotMapped]
        [Required]
        public new IFormFile NewCover { get; set; }
    }
}
