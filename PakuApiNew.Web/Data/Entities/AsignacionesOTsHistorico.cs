using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class AsignacionesOTsHistorico
    {
        [Key]
        public int IDHISTO { get; set; }
        public string PROYMODULO { get; set; }
        public DateTime? FECHA { get; set; }
        public string HORA { get; set; }
        public int IDGAOS { get; set; }
        public int CODIGOCIERRE { get; set; }
        public DateTime? FECHAEVENTO { get; set; }
        public string HORAEVENTO { get; set; }
        public string EQUIVALENCIA { get; set; }
        public string RESPUESTA { get; set; }
        public int UserID { get; set; }
        public string Terminal { get; set; }
        public int? IDUserGaos { get; set; }
        public int InformadaCliente { get; set; }
     }
}