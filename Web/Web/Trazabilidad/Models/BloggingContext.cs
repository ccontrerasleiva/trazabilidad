using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ViewModels.Models;

namespace Trazabilidad.Models
{
    public class BloggingContext: DbContext
    {
        public DbSet<ViewModels.Models.Trazabilidad> Trazabilidads { get; set; }
        public DbSet<TrazabilidadMovLocomotora> TrazabilidadMovLocomotoras { get; set; }
        public DbSet<TrazabilidadMovCarro> TrazabilidadMovCarros { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
    }
}