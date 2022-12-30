using System.ComponentModel.DataAnnotations;

namespace RecycleCoinMvc.Models
{
    public class UserLoginViewModel
    {
        [Required] 
        public string Username { get; set; }

        [Required] 
        public string Password { get; set; }

    }
}