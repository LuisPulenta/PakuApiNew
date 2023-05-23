using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Motivo
    {
        [Key]
        public int ID { get; set; }
        public string MOTIVO { get; set; }
        public int MuestraParaEntregado { get; set; }
        public int ExclusivoCliente { get; set; }
        public int Activo { get; set; }
    }
}