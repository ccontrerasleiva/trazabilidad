
namespace Data.Entities
{
    using Data.Extensions;

    internal class TrazaUbicacionLocomotora : BaseEntity<Domain.Models.TrazaUbicacionLocomotora>
    {
        public TrazaUbicacionLocomotora()
        {
            ToTable("Traza_Ubicacion_Locomotora");


            Property(s => s.Id)
                        .HasColumnName("IdTrazaUbicacionLocomotora").IsRequired();
            HasKey(be => be.Id);



            #region Locomotora
            Property(ot => ot.IdLocomotora)
                .HasColumnName("IdLocomotora")
                .IsRequired();

            HasRequired(rt => rt.DescripcionUbiLocomotora)
                .WithMany(st => st.TrazaUbi_Locomotora)
                .HasForeignKey(r => r.IdLocomotora)
                .WillCascadeOnDelete(false);
            #endregion Locomotora

            #region Ruta
            Property(ot => ot.IdRuta)
                .HasColumnName("IdRuta")
                .IsOptional()
                .IsRequired();

            HasRequired(rt => rt.DescripcionUbiRuta)
                .WithMany(st => st.TrazaUbiRuta_Locomotora)
                .HasForeignKey(r => r.IdRuta)
                .WillCascadeOnDelete(false);
            #endregion Ruta

            Property(s => s.IdTrazabilidadMovLocomotora).HasColumnName("IdTrazabilidadMovLocomotora").IsOptional();

            Property(s => s.PesoNeto).HasColumnName("PesoNeto").IsOptional();

        }
    }
}
