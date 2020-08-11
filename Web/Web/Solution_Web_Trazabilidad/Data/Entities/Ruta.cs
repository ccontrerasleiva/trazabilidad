namespace Data.Entities
{
    using Data.Extensions;

    internal class Ruta : BaseEntity<Domain.Models.Ruta>
    {
        public Ruta()
        {
            ToTable("Ruta");

            Property(s => s.Id)
                        .HasColumnName("IdRuta").IsRequired();
            HasKey(be => be.Id);


            //mucho es a uno
            #region Destination

            Property(ot => ot.Descripcion)
                .HasColumnName("Descripcion")
                .IsRequired();

            Property(s => s.FechaHoraInicio)
                        .HasColumnName("FechaHoraInicio").IsRequired();
            Property(s => s.FechaHoraTermino)
                        .HasColumnName("FechaHoraTermino").IsRequired();

            #endregion Destination


            #region Trazabilidad

            #region Ruta
            HasMany(st => st.TrazabilidadRuta)
               .WithRequired(rt => rt.DescripcionRuta)
               .HasForeignKey(rt => rt.IdRuta)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion
        }
    }
}