
namespace Data.Entities
{
    using Data.Extensions;

    internal class TrazaUbicacionCarro : BaseEntity<Domain.Models.TrazaUbicacionCarro>
    {
        public TrazaUbicacionCarro()
        {
            ToTable("Traza_Ubicacion_Carro");


            Property(s => s.Id)
                        .HasColumnName("IdTrazaUbicacionCarro").IsRequired();
            HasKey(be => be.Id);



            #region Contenedor
            Property(ot => ot.IdCarro)
                .HasColumnName("IdCarro")
                .IsRequired();

            HasRequired(rt => rt.DescripcionUbiCarro)
                .WithMany(st => st.TrazaUbi_Carro)
                .HasForeignKey(r => r.IdCarro)
                .WillCascadeOnDelete(false);
            #endregion Contenedor

            #region Ruta
            Property(ot => ot.IdRuta)
                .HasColumnName("IdRuta")
                .IsOptional()
                .IsRequired();

            HasRequired(rt => rt.DescripcionUbiRuta)
                .WithMany(st => st.TrazaUbiRuta_Carro)
                .HasForeignKey(r => r.IdRuta)
                .WillCascadeOnDelete(false);
            #endregion Ruta

            Property(s => s.IdTrazabilidadMovCarro).HasColumnName("IdTrazabilidadMovCarro").IsOptional();

            Property(s => s.PesoNeto).HasColumnName("PesoNeto").IsOptional();

        }
    }
}
