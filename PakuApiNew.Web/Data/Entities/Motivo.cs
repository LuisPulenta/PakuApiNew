using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Motivo
    {
        [Key]
        public int ID { get; set; }
        public string MOTIVO { get; set; }
    }
}