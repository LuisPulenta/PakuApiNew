using Microsoft.EntityFrameworkCore;
using PakuApiNew.Web.Data.Entities;

namespace PakuApiNew.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Usuario> SubContratistasUsrWebs { get; set; }
        public DbSet<Ruta> p_Rutas2 { get; set; }
        public DbSet<Parada> p_Paradas2{ get; set; }
        public DbSet<Envio> p_Envios2 { get; set; }
    }
}

