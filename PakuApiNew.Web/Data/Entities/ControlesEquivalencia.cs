using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class ControlesEquivalencia
    {
        public int ID { get; set; }
        [Key]
        public string DECO1 { get; set; }
        public string CODIGOEQUIVALENCIA { get; set; }
        public string DESCRIPCION { get; set; }

        public string ProyectoModulo { get; set; }

        
    }
}