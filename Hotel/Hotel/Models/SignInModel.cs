using System.ComponentModel.DataAnnotations;
namespace Hotel.Models
{
    public class SignInModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }


        public string RememberMe { get; set; }

        public string Email { get; set; }
    }
}
