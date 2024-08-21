using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class DestinosGeoCoding
    {
        [Key]
        public int Documento { get; set; }
        public string PosX { get; set; }
        public string PosY { get; set; }
        public DateTime FechaAlta { get; set; }
        public string DomicilioAPP { get; set; }
        public string DomicilioHere { get; set; }
        public int IDProveedor { get; set; }
    }
}
