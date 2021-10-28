using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace InnovativeSoftware.DTOs
{
    public class RegisterDto
    {
        [Required] 
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public string IfttToken { get; set; }
    }
}