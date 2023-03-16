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
        public DbSet<Proveedor> p_Proveedores { get; set; }
        public DbSet<Motivo> p_Motivos { get; set; }
        public DbSet<Seguimiento> p_Seguimiento { get; set; }
        public DbSet<AsignacionesOT> AsignacionesOTs { get; set; }
        public DbSet<AsignacionesOT2> AsignacionesOTs2 { get; set; }
        public DbSet<AsignacionesOtsEquiposExtra> AsignacionesOtsEquiposExtras { get; set; }
        public DbSet<ControlesEquivalencia> ControlesEquivalencias { get; set; }
        public DbSet<CodCierre> CodigosCierre { get; set; }
        public DbSet<FuncionesApp> FuncionesApps { get; set; }
        public DbSet<WebSesion> WebSesions { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<SubContratistasUsrVehiculo> SubContratistasUsrVehiculos { get; set; }
        public DbSet<Vista_AcumuladosEquiposSinDevolver> Vista_AcumuladosEquiposSinDevolver { get; set; }
        public DbSet<AsignacionesOtsTurno> AsignacionesOtsTurnos { get; set; }
    }
}