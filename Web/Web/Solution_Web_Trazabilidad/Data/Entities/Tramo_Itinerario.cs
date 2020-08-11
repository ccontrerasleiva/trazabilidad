namespace Data.Entities
{
    using Data.Extensions;

    internal class Tramo_Itinerario : BaseEntity<Domain.Models.Tramo_Itinerario>
    {
        public Tramo_Itinerario()
        {
            ToTable("TR_Tramo_Itinerario");

            Property(s => s.Id)
                        .HasColumnName("Id_Tramo_Itinerario").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Hora_Salida_Planificada)
                        .HasColumnName("Hora_Salida_Planificada");
            Property(s => s.Hora_Llegada_Planificada)
                        .HasColumnName("Hora_Llegada_Planificada");
            Property(s => s.Tiempo_Viaje)
                        .HasColumnName("Tiempo_Viaje").IsRequired();
            Property(s => s.Observaciones)
                        .HasColumnName("Observaciones");

            Property(s => s.Detencion)
                        .HasColumnName("Detencion");


            #region Id_Tramo

            Property(ot => ot.Id_Tramo)
                .HasColumnName("Id_Tramo")
                .IsRequired();

            HasRequired(rt => rt.Tramo)
                .WithMany(st => st.Tramo_Itinerario)
                .HasForeignKey(r => r.Id_Tramo)
                .WillCascadeOnDelete(false);

            #endregion Id_Tramo

            #region Id_Ruta

            Property(ot => ot.Id_Ruta)
                .HasColumnName("Id_Ruta")
                .IsRequired();

            HasRequired(rt => rt.Ruta)
                .WithMany(st => st.Tramo_Itinerarios)
                .HasForeignKey(r => r.Id_Ruta)
                .WillCascadeOnDelete(false);

            #endregion Id_Ruta


        }
    }
}