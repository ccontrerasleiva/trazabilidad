namespace Data.Entities
{
    using Data.Extensions;

    internal class Itinerario : BaseEntity<Domain.Models.Itinerario>
    {
        public Itinerario()
        {
            ToTable("TR_Itinerario");

            Property(s => s.Id)
                        .HasColumnName("Id_Itinerario").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion");
            Property(s => s.Fecha_Inicio_Vigencia)
                        .HasColumnName("Fecha_Inicio_Vigencia").IsRequired();
            Property(s => s.Fecha_Fin_Vigencia)
                        .HasColumnName("Fecha_Fin_Vigencia").IsRequired();
            Property(s => s.Frecuencia_Lunes)
                        .HasColumnName("Frecuencia_Lunes");
            Property(s => s.Frecuencia_Martes)
                        .HasColumnName("Frecuencia_Martes");
            Property(s => s.Frecuencia_Miercoles)
                        .HasColumnName("Frecuencia_Miercoles");
            Property(s => s.Frecuencia_Jueves)
                        .HasColumnName("Frecuencia_Jueves");
            Property(s => s.Frecuencia_Viernes)
                        .HasColumnName("Frecuencia_Viernes");
            Property(s => s.Frecuencia_Sabado)
                        .HasColumnName("Frecuencia_Sabado");
            Property(s => s.Frecuencia_Domingo)
                        .HasColumnName("Frecuencia_Domingo");
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();

            //mucho es a uno
            #region Estacion
            #region Destination
            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsRequired();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.ItinerarioD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);
            #endregion

            #region Origin
            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsRequired();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.ItinerarioO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);
            #endregion
            #endregion


            #region Servicio
            Property(ot => ot.Id_Servicio)
                .HasColumnName("Id_Servicio")
                .IsRequired();
            //revisar
            HasRequired(rt => rt.Servicio)
                .WithMany(st => st.Itinerario)
                .HasForeignKey(r => r.Id_Servicio)
                .WillCascadeOnDelete(false);
            #endregion

            //uno es a muchos
            #region tarea Patio

            HasMany(st => st.Tarea_Patio)
                .WithRequired(rt => rt.Itinerario)
                .HasForeignKey(rt => rt.Id_Itinerario)
                .WillCascadeOnDelete(false);

            #endregion tarea Patio

            #region Tren

            HasMany(st => st.Tren)
                .WithRequired(rt => rt.Itinerario)
                .HasForeignKey(rt => rt.Id_Itinerario)
                .WillCascadeOnDelete(false);

            #endregion Tren

            #region Ruta

            HasMany(st => st.Ruta)
                .WithRequired(rt => rt.Itinerario)
                .HasForeignKey(rt => rt.Id_Itinerario)
                .WillCascadeOnDelete(false);

            #endregion Ruta
        }
    }
}
