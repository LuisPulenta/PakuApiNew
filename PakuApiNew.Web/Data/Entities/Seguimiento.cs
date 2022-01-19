using System.ComponentModel.DataAnnotations;


namespace PakuApiNew.Web.Data.Entities
{
    public class Seguimiento
    {
        [Key]
        public int ID { get; set; }
        public int? IDENVIO { get; set; }
        public int? IDETAPA { get; set; }
        public int? ESTADO { get; set; }
        public int? IDUSUARIO { get; set; }
        public int? FECHA { get; set; }
        public string HORA { get; set; }
        public string OBSERVACIONES { get; set; }
        public string MOTIVO { get; set; }
        public string NOTACHOFER { get; set; }
    }
}