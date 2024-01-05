using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Models
{
    public class UsuarioRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}