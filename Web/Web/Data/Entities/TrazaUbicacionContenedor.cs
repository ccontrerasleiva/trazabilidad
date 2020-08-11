
namespace Data.Entities
{
    using Data.Extensions;

    internal class TrazaUbicacionContenedor : BaseEntity<Domain.Models.TrazaUbicacionContenedor>
    {
        public TrazaUbicacionContenedor()
        {
            ToTable("Traza_Ubicacion_Contenedor");


            Property(s => s.Id)
                        .HasColumnName("IdTrazaUbicacionContenedor").IsRequired();
            HasKey(be => be.Id);



            #region Contenedor
            Property(ot => ot.IdContenedor)
                .HasColumnName("IdContenedor")
                .IsRequired();

            HasRequired(rt => rt.DescripcionUbiContenedor)
                .WithMany(st => st.TrazaUbi_Contenedor)
                .HasForeignKey(r => r.IdContenedor)
                .WillCascadeOnDelete(false);
            #endregion Contenedor

            #region Ruta
            Property(ot => ot.IdRuta)
                .HasColumnName("IdRuta")
                .IsOptional()
                .IsRequired();

            HasRequired(rt => rt.DescripcionUbiRuta)
                .WithMany(st => st.TrazaUbiRuta_Contenedor)
                .HasForeignKey(r => r.IdRuta)
                .WillCascadeOnDelete(false);
            #endregion Ruta

            Property(s => s.IdTrazabilidadMovCarro).HasColumnName("IdTrazabilidadMovCarro").IsOptional();

            Property(s => s.PesoNeto).HasColumnName("PesoNeto").IsOptional();

        }
    }
}
