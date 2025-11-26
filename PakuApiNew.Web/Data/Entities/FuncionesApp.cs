using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class FuncionesApp
    {
        [Key]
        public string PROYECTOMODULO { get; set; }

        public int HabilitaFoto { get; set; }
        public int HabilitaDNI { get; set; }
        public int HabilitaEstadisticas { get; set; }
        public int HabilitaFirma { get; set; }
        public int SerieObligatoria { get; set; }
        public int CodigoFinal { get; set; }
        public int HabilitaOtroRecupero { get; set; }
        public int HabilitaCambioModelo { get; set; }
        public string Token { get; set; }
        public int HabilitaVerPdf { get; set; }
        public int HabilitaModulo { get; set; }
        public int HabilitaRecuperoParcial { get; set; }
    }
}