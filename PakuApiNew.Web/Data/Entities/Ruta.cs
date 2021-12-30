using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Ruta
    {
        [Key]
        public int Id { get; set; }
        public int IdFletero { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
    }
}
