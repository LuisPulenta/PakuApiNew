using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Models
{
    public class AsignacionesConsultaCliente
    {
        public string PROYECTOMODULO { get; set; }
        public string CLIENTE { get; set; }
        public string RECUPIDJOBCARD { get; set; }
        [Key]
        public int IDREGISTRO { get; set; }
        public string ESTADOGAOS { get; set; }
        public int? CodigoCierre { get; set; }
        public string DECO1 { get; set; }
        public string ESTADO3 { get; set; }
        public string MODELO { get; set; }
        public string Motivos { get; set; }
        public DateTime? FECHACUMPLIDA { get; set; }
        public DateTime? HsCumplidaTime { get; set; }
        public string Documento { get; set; }
        public string MarcaModeloId { get; set; }
        public DateTime? Fc_inicio_base { get; set; }
        public DateTime? Fc_fin_base { get; set; }
        public DateTime? FechaEvento1 { get; set; }
        public string Evento1 { get; set; }
        public DateTime? FechaEvento2 { get; set; }
        public string Evento2 { get; set; }
    }
}