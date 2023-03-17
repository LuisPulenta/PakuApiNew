using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class SubContratistasUsrVehiculo
    {
        [Key]
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
        [Display(Name = "Foto")]
        
        public string DniFrenteFullPath => DNIFrente == string.Empty
           ? $"http://fleetsa.serveftp.net:88/PakuApiNew/images/DNI/noimage.png"
            : $"http://fleetsa.serveftp.net:88/PakuApiNew{DNIFrente.Substring(1)}";

        public string DniDorsoFullPath => DNIDorso == string.Empty
           ? $"http://fleetsa.serveftp.net:88/PakuApiNew/images/DNI/noimage.png"
            : $"http://fleetsa.serveftp.net:88/PakuApiNew{DNIFrente.Substring(1)}";

        public string CarnetConducirFullPath => CarnetConducir == string.Empty
           ? $"http://fleetsa.serveftp.net:88/PakuApiNew/images/DNI/noimage.png"
            : $"http://fleetsa.serveftp.net:88/PakuApiNew{DNIFrente.Substring(1)}";
    }
}
