using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class AsignacionesOtsTurno
    {
        [Key]
        public int IDTurno { get; set; }
        public int IdUser { get; set; }
        public DateTime? FechaCarga { get; set; }
        public DateTime? FechaTurno { get; set; }
        public int? HoraTurno { get; set; }
        public DateTime? FechaConfirmaTurno { get; set; }
        public int IDUserConfirma { get; set; }
        public DateTime? FechaTurnoConfirmado { get; set; }
        public int? HoraTurnoConfirmado { get; set; }
        public string Concluido { get; set; }
    }
}
