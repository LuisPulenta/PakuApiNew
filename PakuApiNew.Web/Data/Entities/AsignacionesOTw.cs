using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class AsignacionesOTw
    {
        [Key]
        public int IDREGISTRO { get; set; }
        public string SUBAGENTEMERCADO { get; set; }
        public string RECUPIDJOBCARD { get; set; }
        public string CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string Documento { get; set; }
        public string DOMICILIO { get; set; }        
        public string ENTRECALLE1 { get; set; }
        public string ENTRECALLE2 { get; set; }
        public string CP { get; set; }
        public string PROVINCIA { get; set; }
        public string LOCALIDAD { get; set; }
        public string Partido { get; set; }
        public string ZONA { get; set; }
        public string TELEFONO { get; set; }
        public string GRXX { get; set; }
        public string GRYY { get; set; }
        public string DECO1 { get; set; }
        public string CMODEM1 { get; set; }
        public DateTime? FECHACARGA { get; set; }
        public string ESTADO { get; set; }
        public string MODELO { get; set; }
        public string SMARTCARD { get; set; }
        public string RUTA { get; set; }
        public string PROYECTOMODULO { get; set; }
        public string SUBCON { get; set; }
        public string CAUSANTEC { get; set; }
        public string Observacion { get; set; }
        public string EmailCliente { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public string MarcaModeloId { get; set; }
        public string Novedades { get; set; }
        public string IDSuscripcion { get; set; }
        public string ItemsID { get; set; }
        public string SectorOperativo { get; set; }
        public string Motivos { get; set; }
        public string FranjaEntrega { get; set; }
        public string TelefAlternativo1 { get; set; }
        public string TelefAlternativo2 { get; set; }
        public string TelefAlternativo3 { get; set; }
        public string TelefAlternativo4 { get; set; }
        public string TipoTel1 { get; set; }
        public string TipoTel2 { get; set; }
        public string TipoTel3 { get; set; }
        public string TipoTel4 { get; set; }
        public string DniRecibe { get; set; }
        public string NombreRecibe { get; set; }
        public string NroSerieEntrega { get; set; }
        public string NroSerieEntrega1 { get; set; }
        public string ClaveToken { get; set; }
        public int? IDGaos { get; set; }

    }
}