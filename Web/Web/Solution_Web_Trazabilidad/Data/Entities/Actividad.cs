namespace Data.Entities
{
    using Data.Extensions;

    internal class Actividad : BaseEntity<Domain.Models.Actividad>
    {
        public Actividad()
        {
            ToTable("TR_Actividad");

            Property(s => s.Id)
                           .HasColumnName("Id_Actividad").IsRequired();
            HasKey(be => be.Id);
            //Property(s => s.Id_Jornada)
            //               .HasColumnName("Id_Jornada").IsRequired();
            Property(s => s.Estado)
                          .HasColumnName("Estado").IsRequired();
            Property(s => s.Tipo)
                           .HasColumnName("Tipo").IsRequired();
            Property(s => s.THapa)
                          .HasColumnName("Tiempo_Hapa").IsOptional();

            //Property(s => s.Id_Tripulante)
            //               .HasColumnName("Id_Tripulante");
            Property(s => s.Hora_Inicio)
                           .HasColumnName("Hora_Inicio").IsRequired();
            Property(s => s.Hora_Fin)
                           .HasColumnName("Hora_Fin").IsRequired();
            Property(s => s.Hora_Inicio_Real)
                          .HasColumnName("Hora_Inicio_Real").IsOptional();
            Property(s => s.Hora_Final_Real)
                         .HasColumnName("Hora_Final_Real").IsOptional();
            Property(s => s.Hora_Fin)
                           .HasColumnName("Hora_Fin");
            Property(s => s.Estado)
                           .HasColumnName("Estado").IsRequired();

            //mucho es a uno
            #region Estacion
            #region Destination
            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsOptional();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.ActividadD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);
            #endregion

            #region Origin
            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsOptional();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.ActividadO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);
            #endregion
            #endregion



            #region Id_Jornada

            Property(ot => ot.Id_Jornada)
                .HasColumnName("Id_Jornada")
                .IsOptional();

            HasRequired(rt => rt.Jornada)
                .WithMany(st => st.Actividades)
                .HasForeignKey(r => r.Id_Jornada)
                .WillCascadeOnDelete(false);

            #endregion Id_Jornada

            #region Id_Tripulante

            Property(ot => ot.Id_Tripulante)
                .HasColumnName("Id_Tripulante")
                .IsOptional();

            HasRequired(rt => rt.Tripulante)
                .WithMany(st => st.Actividades)
                .HasForeignKey(r => r.Id_Tripulante)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante

            #region Id_TripulantePersona

            Property(ot => ot.Id_TripulantePersona)
                .HasColumnName("Id_Tripulante_Persona")
                .IsRequired();

            HasRequired(rt => rt.TripulantePersona)
                .WithMany(st => st.Actividades)
                .HasForeignKey(r => r.Id_TripulantePersona)
                .WillCascadeOnDelete(false);

            #endregion Id_TripulantePersona

        }
    }
}