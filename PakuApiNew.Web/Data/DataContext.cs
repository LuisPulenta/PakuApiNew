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
    }
}

