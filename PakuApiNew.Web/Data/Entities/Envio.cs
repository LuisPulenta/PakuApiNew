using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Envio
    {
        [Key]
        public int IDEnvio { get; set; }
        public int? IDPROVEEDOR { get; set; }
        public int? AGENCIANR { get; set; }
        public int? ESTADO { get; set; }
        public string ENVIA { get; set; }
        public string RUTA { get; set; }
        public string ORDENID { get; set; }
        public int? FECHA { get; set; }
        public string HORA { get; set; }
        public string IMEI { get; set; }
        public string TRANSPORTE { get; set; }
        public string CONTRATO { get; set; }
        public string TITULAR { get; set; }
        public string DNI { get; set; }
        public string DOMICILIO { get; set; }
        public string CP { get; set; }
        public decimal? LATITUD { get; set; }
        public decimal? LONGITUD { get; set; }
        public string AUTORIZADO { get; set; }
        public string OBSERVACIONES { get; set; }
        public int? IDCabCertificacion { get; set; }
        public int? IDRemitoProveedor { get; set; }
        public int? IdSubconUsrWeb { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaDistribucion { get; set; }
        public string EntreCalles { get; set; }
        public string Mail { get; set; }
        public string Telefonos { get; set; }
        public string Localidad { get; set; }
        public int? Tag { get; set; }
        public string PROVINCIA { get; set; }
        public DateTime? FechaEntregaCliente { get; set; }
        public string ScaneadoIn { get; set; }
        public string ScaneadoOut { get; set; }
        public int? IngresoDeposito { get; set; }
        public int? SalidaDistribucion { get; set; }
        public int? IDRuta { get; set; }
        public int? NroSecuencia { get; set; }
        public string FechaHoraOptimoCamino { get; set; }
        public int? Bultos { get; set; }
        public string Peso { get; set; }
        public string Alto { get; set; }
        public string Ancho { get; set; }
        public string Largo { get; set; }
        public int? IdComprobante { get; set; }
        public string EnviarMailSegunEstado { get; set; }
        public DateTime? FechaRuta { get; set; }
        public string OrdenIDparaOC { get; set; }
        public string HashUnico { get; set; }
        public int? BultosPikeados { get; set; }
        public string CentroDistribucion { get; set; }
        public DateTime? FechaUltimaActualizacion { get; set; }
        public string Volumen { get; set; }
        public int? AvonZoneNumber { get; set; }
        public int? AvonSectorNumber { get; set; }
        public string AvonAccountNumber { get; set; }
        public int? AvonCampaignNumber { get; set; }
        public int? AvonCampaignYear { get; set; }
        public string DomicilioCorregido { get; set; }
        public int? DomicilioCorregidoUsando { get; set; }
        public string UrlFirma { get; set; }
        public string UrlDNI { get; set; }
        [Display(Name = "DNI")]
        public string UrlDNIFullPath => string.IsNullOrEmpty(UrlDNI)
          ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
          : $"http://181.174.199.118:88/PakuApiNew{UrlDNI.Substring(1)}";
        public int? UltimoIdMotivo { get; set; }
        public string UltimaNotaFletero { get; set; }
        public int? IdComprobanteDevolucion { get; set; }
        public string Turno { get; set; }
        public string BarrioEntrega { get; set; }
        public string PartidoEntrega { get; set; }
        public int? AvonDayRoute { get; set; }
        public int? AvonTravelRoute { get; set; }
        public int? AvonSecuenceRoute { get; set; }
        public int? AvonInformarInclusion { get; set; }
        public decimal? LATITUD2 { get; set; }
        public decimal? LONGITUD2 { get; set; }
        public string AvonCodAmount { get; set; }
    }
}