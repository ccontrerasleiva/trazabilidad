namespace Data.Entities
{
    using Data.Extensions;

    internal class H_Tren_Tramo : BaseEntity<Domain.Models.H_Tren_Tramo>
    {
        public H_Tren_Tramo()
        {
            ToTable("TH_Tren_Tramo");

            Property(s => s.Id)
                        .HasColumnName("Id_Tren_Tramo").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Id_Origen)
                        .HasColumnName("Id_Origen");
            Property(s => s.Id_Destino)
                        .HasColumnName("Id_Destino");
            Property(s => s.Hora_Salida_Real)
                        .HasColumnName("Hora_Salida_Real");
            Property(s => s.Tiempo_Acumulado)
                        .HasColumnName("Tiempo_Acumulado");
            Property(s => s.Hora_Llegada_Real)
                        .HasColumnName("Hora_Llegada_Real");
            //Property(s => s.Fecha_Creacion)
            //               .HasColumnName("Fecha_Creacion").IsRequired();
            //Property(s => s.Fecha_Modificacion)
            //               .HasColumnName("Fecha_Modificacion");

            #region Id_Tren_Tramo

            Property(ot => ot.Id_TTramos)
                .HasColumnName("Id_TTramos")
                .IsRequired();

            //HasRequired(rt => rt.Id_TTramo)
            //    .WithMany(st => st.H_Tren_Tramos)
            //    .HasForeignKey(r => r.Id_TTramos)
            //    .WillCascadeOnDelete(false);

            #endregion Id_Tren_Tramo
        }
    }
}