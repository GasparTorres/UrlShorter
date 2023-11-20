using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models
{
    public class AuthenticationRequestDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
