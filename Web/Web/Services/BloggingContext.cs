using System;
using System.Data.Entity;
using ViewModels.Models;

namespace Services
{
    //internal class BloggingContext : IDisposable
      public class BloggingContext : DbContext
    {
        private const string ConnectionStringName = "DefaultConnection";

        public BloggingContext() : base(ConnectionStringName)
        {
            Configuration.LazyLoadingEnabled = true;
        }
        public DbSet<ViewModels.Models.Trazabilidad> Trazabilidads { get; set; }
        public DbSet<TrazabilidadMovLocomotora> TrazabilidadMovLocomotoras { get; set; }
        public DbSet<TrazabilidadMovCarro> TrazabilidadMovCarros { get; set; }
        public DbSet<Ruta> Rutas { get; set; }

        internal object CreateCommand()
        {
            throw new NotImplementedException();
        }
    }
}