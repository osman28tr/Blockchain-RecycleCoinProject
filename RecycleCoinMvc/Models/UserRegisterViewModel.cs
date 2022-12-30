using System.ComponentModel.DataAnnotations;

namespace RecycleCoinMvc.Models
{
    public class UserRegisterViewModel
    {
        public long? TcNo { get; set; }
        
        [Required] 
        public string Name { get; set; }

        [Required] 
        public string Lastname { get; set; }

        public int? Year { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

        public bool IsNotTcPerson { get; set; }

    }
}