namespace Data.Entities
{
    using System.Data.Entity.ModelConfiguration;


    internal class UserTokenCache : EntityTypeConfiguration<Domain.Models.UserTokenCache>
    {
        public UserTokenCache()
        {
            ToTable("CacheTokenUsuarios");

            HasKey(ut => ut.UserTokenCacheId);

            Property(ut => ut.UserTokenCacheId)
                .HasColumnName("id");

            Property(ut => ut.WebUserUniqueId)
                .HasColumnName("id_usuario_web");

            Property(ut => ut.LastWrite)
                .HasColumnName("ultima_escritura");

            Property(ut => ut.CacheBits)
                .HasColumnName("bits_cache");
        }
    }
}
