namespace Data.Entities
{
    using Data.Extensions;


    internal class Jornada : BaseEntity<Domain.Models.Jornada>
    {
        public Jornada()
        {
            ToTable("TM_Jornada");

            Property(s => s.Id)
                        .HasColumnName("Id_Jornada").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Fecha)
                        .HasColumnName("Fecha").IsRequired();
            Property(s => s.Estado)
                .HasColumnName("Estado").IsRequired();
            Property(s => s.Hora_Inicio)
                        .HasColumnName("Hora_Inicio").IsOptional();
            Property(s => s.Hora_Fin)
                        .HasColumnName("Hora_Fin").IsOptional();

            Property(s => s.Aprobado)
                        .HasColumnName("Aprobado").IsOptional();
            Property(s => s.Observacion)
                        .HasColumnName("Observacion")
                        .HasColumnType("varchar")
                        .HasMaxLength(100)
                        .IsOptional();

            Property(s => s.Tipo)
                            .HasColumnName("Tipo")
                            .HasColumnType("char")
                            .HasMaxLength(2);

            //mucho es a uno
            #region origen

            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsOptional();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.JornadaO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);

            #endregion origen

            #region destino

            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsOptional();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.JornadaD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);

            #endregion destino

            #region Id_Tripulante_Persona

            Property(ot => ot.Id_Tripulante_Persona)
                .HasColumnName("Id_Tripulante_Persona")
                .IsRequired();

            HasRequired(rt => rt.Tripulante_Persona)
                .WithMany(st => st.Jornadas)
                .HasForeignKey(r => r.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante_Persona

            //uno es a mucho
            #region Actividad

            HasMany(st => st.Actividades)
                .WithRequired(rt => rt.Jornada)
                .HasForeignKey(rt => rt.Id_Jornada)
                .WillCascadeOnDelete(false);

            #endregion Actividad

        }
    }
}