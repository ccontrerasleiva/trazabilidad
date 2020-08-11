namespace Data.Entities
{
    using Data.Extensions;

    internal class Locomotora : BaseEntity<Domain.Models.Locomotora>
    {
        public Locomotora()
        {
            ToTable("Locomotora");

            Property(s => s.Id)
                        .HasColumnName("IdLocomotora");
            HasKey(be => be.Id);
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion").IsRequired();
            Property(s => s.Patente)
                        .HasColumnName("Patente").IsRequired();
            Property(s => s.PesoTara)
                        .HasColumnName("PesoTara").IsRequired();

            //mucho es a uno

            #region TrazabilidadMovLocomotora

            #region Locomotora
            HasMany(st => st.TrazaMoviLoco_Loco)
               .WithRequired(st => st.Locomotora)
               .HasForeignKey(rt => rt.IdLocomotora)
               .WillCascadeOnDelete(false);
            #endregion Locomotora

            #endregion TrazabilidadMovLocomotora

        }
    }
}