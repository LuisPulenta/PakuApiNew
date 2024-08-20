using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Ruta
    {
        [Key]
        public int IDRuta { get; set; }
        public int IDUser { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Nombre { get; set; }
        public int Estado { get; set; }
        public int HabilitaCatastro { get; set; }
        
        public ICollection<Parada> Paradas { get; set; }
        public ICollection<Envio> Envios { get; set; }
    }
}
