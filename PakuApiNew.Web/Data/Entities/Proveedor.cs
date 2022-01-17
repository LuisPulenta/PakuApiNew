using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Proveedor
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CLAVEACCESO { get; set; }
        public int? PERMISO { get; set; }
        public int? PERMISO2 { get; set; }
        public string EMAIL { get; set; }
        public string Iniciales { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Responsable { get; set; }
        public string CondicionesContrato { get; set; }
        public int? Tag { get; set; }
        public int? Estado { get; set; }
        public string CUIT { get; set; }
        public int? ImportacionGenerica { get; set; }
        public int? EnviarNotifAdestinatario { get; set; }
        public int? EnviarCopiaAcliente { get; set; }
        public int? EnviarResumenNotifAcliente { get; set; }
        public string PesoCaja { get; set; }
        public string AltoCaja { get; set; }
        public string AnchoCaja { get; set; }
        public string LargoCaja { get; set; }
        public string PesoMaxPallet { get; set; }
        public string AltoMaxPallet { get; set; }
        public string AnchoMaxPallet { get; set; }
        public string LargoMaxPallet { get; set; }
        public int? CantidadDeCajas { get; set; }
    }
}