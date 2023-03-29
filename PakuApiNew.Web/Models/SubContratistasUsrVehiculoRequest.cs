using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakuApiNew.Web.Models
{
    public class SubContratistasUsrVehiculoRequest
    {
        public int ID { get; set; }
        public int IdUser { get; set; }
        public string DNIFrente { get; set; }
        public string DNIDorso { get; set; }
        public string CarnetConducir { get; set; }
        public DateTime? FechaVencCarnet { get; set; }
        public string Dominio { get; set; }
        public int? ModeloAnio { get; set; }
        public string Marca { get; set; }
        public DateTime? FechaVencVTV { get; set; }
        public string Gas { get; set; }
        public DateTime? FechaObleaGas { get; set; }
        public DateTime? UltimaActualizacion { get; set; }
        public byte[] DNIFrenteImageArray { get; set; }
        public byte[] DNIDorsoImageArray { get; set; }
        public byte[] CarnetConducirImageArray { get; set; }
        public string NroPolizaSeguro { get; set; }
        public DateTime? FechaVencPoliza { get; set; }
        public string Compania { get; set; }
        public byte[] LinkVtvImageArray { get; set; }
        public byte[] LinkObleaGasImageArray { get; set; }
        public byte[] LinkPolizaSeguroImageArray { get; set; }
        public byte[] LinkCedulaImageArray { get; set; }
        public byte[] LinkAntecedentesImageArray { get; set; }
    }
}
