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
        public DbSet<Ruta> p_Rutas { get; set; }
        public DbSet<Parada> p_Paradas{ get; set; }
        public DbSet<Envio> p_Envios { get; set; }
        public DbSet<Proveedor> p_Proveedores { get; set; }
        public DbSet<Motivo> p_Motivos { get; set; }
        public DbSet<Seguimiento> p_Seguimiento { get; set; }
    }
}