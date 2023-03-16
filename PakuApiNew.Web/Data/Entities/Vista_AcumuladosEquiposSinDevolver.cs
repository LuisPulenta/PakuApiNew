using System.ComponentModel.DataAnnotations;

namespace PakuApiNew.Web.Data.Entities
{
    public class Vista_AcumuladosEquiposSinDevolver
    {
            [Key] 
            public int UserID { get; set; }
        public string APELLIDONOMBRE { get; set; }
        public int? SinIngresoDeposito { get; set; }
        public int? DTV { get; set; }
        public int? Cable { get; set; }
        public int? Tasa { get; set; }
        public int? TLC { get; set; }
        public int? Prisma { get; set; }
        public int? Teco { get; set; }
        public int? SuperC { get; set; }


    }
}
