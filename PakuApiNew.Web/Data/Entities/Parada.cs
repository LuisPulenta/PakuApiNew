using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Parada
    {
        [Key]
        public int IDParada { get; set; }
        public int IDRuta { get; set; }
        public int? IDEnvio { get; set; }
        public int? Tag { get; set; }
        public int? Secuencia { get; set; }
        public string Leyenda { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string IconoPropio { get; set; }
        public string IDmapa { get; set; }
        public int? Distancia { get; set; }
        public int? Tiempo { get; set; }
        public int? Estado { get; set; }
        public DateTime? Fecha { get; set; }
        public string Hora { get; set; }
        public int? IdMotivo { get; set; }
        public string NotaChofer { get; set; }
        public int? NuevoOrden { get; set; }
        public int? IDCabCertificacion { get; set; }
        public int? IdLiquidacionFletero { get; set; }
        public string Turno { get; set; }
        //[JsonIgnore]
        //public Ruta Ruta { get; set; }

    }
}