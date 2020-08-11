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

            Property(s => s.Sigla_Codelco).HasColumnName("Sigla_Codelco").IsOptional();
            Property(s => s.Sigla_Codelco).HasColumnType("varchar");
            Property(s => s.Sigla_Codelco).HasMaxLength(50);

            Property(s => s.Longitud).HasColumnName("Longitud").IsOptional();
            Property(s => s.Longitud).HasColumnType("decimal");
            Property(s => s.Longitud).HasPrecision(18,14);

            Property(s => s.Latitud).HasColumnName("Latitud").IsOptional();
            Property(s => s.Latitud).HasColumnType("decimal");
            Property(s => s.Latitud).HasPrecision(18, 14);

            Property(s => s.FechaHoraInicio)
                        .HasColumnName("FechaHoraInicio").IsRequired();
            Property(s => s.FechaHoraTermino)
                        .HasColumnName("FechaHoraTermino").IsRequired();

            Property(s => s.Nombre).HasColumnName("Nombre").IsOptional();

            Property(s => s.Title).HasColumnName("Title").IsOptional();
            Property(s => s.Title).HasColumnType("varchar");
            Property(s => s.Title).HasMaxLength(60);

            Property(s => s.Sentido).HasColumnName("Sentido").IsOptional();

            Property(s => s.Trocha).HasColumnName("Trocha").IsOptional();
            Property(s => s.Trocha).HasColumnType("varchar");
            Property(s => s.Trocha).HasMaxLength(1);

            Property(s => s.Orden).HasColumnName("Orden").IsOptional();

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