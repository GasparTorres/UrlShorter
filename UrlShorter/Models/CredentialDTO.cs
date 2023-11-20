using System.ComponentModel.DataAnnotations;

namespace UrlShorter.Models
{
    public class CredentialDTO
    {
        [Required]

        public string Name { get; set; }
        [Required]
        
        public string Password { get; set; }
    }
}
