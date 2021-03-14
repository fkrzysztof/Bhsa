using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Harissa.Data.Data
{
    [NotMapped]
    public class NewsCreate : News
    {
        [Required]
        public new IFormFile FormFileItem { get; set; }
    }
}
