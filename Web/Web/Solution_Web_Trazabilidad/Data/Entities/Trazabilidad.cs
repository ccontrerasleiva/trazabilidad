
namespace Data.Entities
{
    using Data.Extensions;

    internal class Trazabilidad : BaseEntity<Domain.Models.Trazabilidad>
    {
        public Trazabilidad()
        {
            ToTable("Trazabilidad");


            Property(s => s.Id)
                        .HasColumnName("IdTrazabilidad").IsRequired();
            HasKey(be => be.Id);

            #region Ruta
            Property(ot => ot.IdRuta)
                .HasColumnName("IdRuta")
                .IsOptional();
                //.IsRequired();

            HasRequired(rt => rt.DescripcionRuta)
                .WithMany(st => st.TrazabilidadRuta)
                .HasForeignKey(r => r.IdRuta)
                .WillCascadeOnDelete(false);
            #endregion Ruta

            #region Cliente
            Property(ot => ot.IdCliente)
                .HasColumnName("IdCliente")
                .IsRequired();
            HasRequired(rt => rt.DescripcionCliente)
                .WithMany(st => st.TrazabilidadCliente)
                .HasForeignKey(r => r.IdCliente)
                .WillCascadeOnDelete(false);
            #endregion Cliente
            
            Property(s => s.FechaRegistro).HasColumnName("FechaRegistro").IsOptional();

            Property(s => s.FechaInicio).HasColumnName("FechaInicio").IsOptional();

            Property(s => s.FechaCierre).HasColumnName("FechaCierre").IsOptional();


            #region Conductor
            Property(ot => ot.IdConductor)
                .HasColumnName("IdConductor")
                .IsRequired();
            HasRequired(rt => rt.DescripcionConductor)
                .WithMany(st => st.TrazabilidadConductor)
                .HasForeignKey(r => r.IdConductor)
                .WillCascadeOnDelete(false);
            #endregion Conductor


            

            Property(s => s.Observacion).HasColumnName("Observacion").IsOptional();

            Property(s => s.IdBase).HasColumnName("IdBase").IsOptional();
            Property(s => s.IdBascula).HasColumnName("IdBascula").IsOptional();
            Property(s => s.IdCV).HasColumnName("IdCV").IsOptional();
            Property(s => s.IdEtruck).HasColumnName("IdEtruck").IsOptional();


            #region Trazabilidad

            #region MovLocomotora
            HasMany(st => st.TrazaMoviLoco_Traza)
               .WithRequired(rt => rt.Trazabilidad)
               .HasForeignKey(rt => rt.IdTrazabilidad)
               .WillCascadeOnDelete(false);
            #endregion MovLocomotora

            #endregion Trazabilidad




        }
    }
}
