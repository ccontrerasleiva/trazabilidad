
namespace Data.Entities
{
    using Data.Extensions;

    internal class Conductor : BaseEntity<Domain.Models.Conductor>
    {
        public Conductor()
        {
            ToTable("Conductor");


            Property(s => s.Id)
                        .HasColumnName("IdConductor").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Rut)
              .HasColumnName("Rut").IsOptional();

            Property(s => s.Nombres)
                        .HasColumnName("Nombres").IsRequired();

            Property(s => s.Apellidos)
                        .HasColumnName("Apellidos").IsOptional();

            Property(s => s.Celular)
                        .HasColumnName("Celular").IsOptional();

            #region Trazabilidad

            #region Conductor
            HasMany(st => st.TrazabilidadConductor)
               .WithRequired(rt => rt.DescripcionConductor)
               .HasForeignKey(rt => rt.IdConductor)
               .WillCascadeOnDelete(false);
            #endregion Conductor

            #endregion Trazabilidad
        }
    }
}
