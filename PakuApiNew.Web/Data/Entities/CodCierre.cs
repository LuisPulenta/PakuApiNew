using System.ComponentModel.DataAnnotations;
namespace PakuApiNew.Web.Data.Entities
{
    public class CodCierre
    {

        public string PROYECTOMODULO { get; set; }
        [Key]
        public int CodigoCierre { get; set; }
        public string DESCRIPCION { get; set; }
        public int CierraEnAPP { get; set; }
        public int NoMostrarAPP { get; set; }
        public string EquivalenciaWS { get; set; }
    }
}
