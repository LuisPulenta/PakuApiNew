using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Usuario
    {
        [Key]
        public int IDUser { get; set; }
        public string CODIGO { get; set; }
        public string APELLIDONOMBRE { get; set; }
        public string USRLOGIN { get; set; }
        public string USRCONTRASENA { get; set; }
        public int? HabilitadoWeb { get; set; }
        public string Vehiculo { get; set; }
        public string Dominio { get; set; }
        public string Celular { get; set; }
        public int? Orden { get; set; }
        public int? CentroDistribucion { get; set; }
        public string DNI { get; set; }
        public string Mail { get; set; }
        public string ClaveEmail { get; set; }
        //public ICollection<Ruta> Rutas { get; set; }
    }
}
