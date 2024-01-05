using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Models
{
    public class UsuarioAutorizaRequest
    {
        [Required]
        public int IdUsuarioAutoriza { get; set; }

        [Required]
        public string Login { get; set; }
        [Required]
        public int FechaCaduca { get; set; }
    }
}