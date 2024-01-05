namespace PakuApiNew.Web.Models
{
    public class UsuarioAppResponse
    {
        public int IDUsuario { get; set; }
        public string CodigoCausante { get; set; }
        public string Login { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Estado { get; set; }
        public int? FechaCaduca { get; set; }
        public int? IntentosInvDiario { get; set; }
        public int? OpeAutorizo { get; set; }
    }
}