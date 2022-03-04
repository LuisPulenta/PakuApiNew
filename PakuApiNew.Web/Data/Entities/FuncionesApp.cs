using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class FuncionesApp
    {
        public string PROYECTOMODULO { get; set; }
        [Key]
        public int HabilitaFoto { get; set; }
        public int HabilitaDNI { get; set; }
        public int HabilitaEstadisticas { get; set; }
        public int HabilitaFirma { get; set; }
    }
}
