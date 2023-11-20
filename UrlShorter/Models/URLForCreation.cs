using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UrlShorter.Models
{
    public class URLForCreation
    {
        [Required]
        public int URL { get; set; }

        public int? ID { get; set; }
    }
}
