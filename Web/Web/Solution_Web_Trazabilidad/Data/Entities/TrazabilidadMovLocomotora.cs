
namespace Data.Entities
{
    using Data.Extensions;

    internal class TrazabilidadMovLocomotora : BaseEntity<Domain.Models.TrazabilidadMovLocomotora>
    {
        public TrazabilidadMovLocomotora()
        {
            ToTable("Trazabilidad_Mov_Locomotora");


            Property(s => s.Id)
                        .HasColumnName("IdTrazabilidadMovLocomotora").IsRequired();
            HasKey(be => be.Id);

            #region Trazabilidad
            Property(ot => ot.IdTrazabilidad)
                .HasColumnName("IdTrazabilidad")
                .IsRequired();

            HasRequired(rt => rt.Trazabilidad)
                .WithMany(sd => sd.TrazaMoviLoco_Traza)
                .HasForeignKey(r => r.IdTrazabilidad)
                .WillCascadeOnDelete(false);
            #endregion Trazabilidad


            #region Locomotora
            Property(ot => ot.IdLocomotora)
                .HasColumnName("IdLocomotora")
                .IsRequired();

            HasRequired(rt => rt.Locomotora)
                .WithMany(st => st.TrazaMoviLoco_Loco)
                .HasForeignKey(r => r.IdLocomotora)
                .WillCascadeOnDelete(false);
            #endregion Cliente
          
    }
}
}
