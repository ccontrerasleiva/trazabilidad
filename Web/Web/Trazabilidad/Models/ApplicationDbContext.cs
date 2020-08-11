using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ViewModels.Models;

namespace Trazabilidad.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserTokenCache> UserTokenCacheList { get; set; }

        public DbSet<ViewModels.Models.Trazabilidad> Trazabilidads { get; set; }
        public DbSet<TrazabilidadMovLocomotora> TrazabilidadMovLocomotoras { get; set; }
        public DbSet<TrazabilidadMovCarro> TrazabilidadMovCarros { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
    }

    public class UserTokenCache
    {
        [Key]
        public int UserTokenCacheId { get; set; }
        public string webUserUniqueId { get; set; }
        public byte[] cacheBits { get; set; }
        public DateTime LastWrite { get; set; }
    }
}