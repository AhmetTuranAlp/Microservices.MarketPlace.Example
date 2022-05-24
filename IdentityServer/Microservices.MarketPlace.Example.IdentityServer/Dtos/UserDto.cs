using System.ComponentModel.DataAnnotations;

namespace Microservices.MarketPlace.Example.IdentityServer.Dtos
{
    public class UserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
