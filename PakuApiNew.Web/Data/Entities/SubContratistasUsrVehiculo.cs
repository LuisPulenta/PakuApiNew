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
        public string NroPolizaSeguro { get; set; }
        public DateTime? FechaVencPoliza { get; set; }
        public string Compania { get; set; }
        public string LinkVtv    { get; set; }
        public string LinkObleaGas { get; set; }
        public string LinkPolizaSeguro { get; set; }
        public string LinkCedula { get; set; }
        public string LinkAntecedentes { get; set; }

        public string DniFrenteFullPath => DNIFrente == string.Empty
           ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
            : $"http://181.174.199.118:88/PakuApiNew{DNIFrente.Substring(1)}";

        public string DniDorsoFullPath => DNIDorso == string.Empty
           ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
            : $"http://181.174.199.118:88/PakuApiNew{DNIDorso.Substring(1)}";

        public string CarnetConducirFullPath => CarnetConducir == string.Empty
           ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
            : $"http://181.174.199.118:88/PakuApiNew{CarnetConducir.Substring(1)}";

        public string LinkVtvFullPath => LinkVtv == string.Empty
          ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
           : $"http://181.174.199.118:88/PakuApiNew{LinkVtv.Substring(1)}";

        public string LinkObleaGasFullPath => LinkObleaGas == string.Empty
          ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
           : $"http://181.174.199.118:88/PakuApiNew{LinkObleaGas.Substring(1)}";

        public string LinkPolizaSeguroFullPath => LinkPolizaSeguro == string.Empty
         ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
          : $"http://181.174.199.118:88/PakuApiNew{LinkPolizaSeguro.Substring(1)}";

        public string LinkCedulaFullPath => LinkCedula == string.Empty
         ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
          : $"http://181.174.199.118:88/PakuApiNew{LinkCedula.Substring(1)}";

        public string LinkAntecedentesFullPath => LinkAntecedentes == string.Empty
         ? $"http://181.174.199.118:88/PakuApiNew/images/DNI/noimage.png"
          : $"http://181.174.199.118:88/PakuApiNew{LinkAntecedentes.Substring(1)}";
    }
}
