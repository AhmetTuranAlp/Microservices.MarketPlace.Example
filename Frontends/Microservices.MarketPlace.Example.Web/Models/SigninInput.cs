using System.ComponentModel.DataAnnotations;

namespace Microservices.MarketPlace.Example.Web.Models
{
    public class SigninInput
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Is Remember")]
        public bool IsRemember { get; set; }
    }
}
