namespace Data.Entities
{
    using Data.Extensions;

    internal class Tripulante_Persona : BaseEntity<Domain.Models.Tripulante_Persona>
    {
        public Tripulante_Persona()
        {
            ToTable("TM_Tripulante_Persona");

            Property(s => s.Id)
                        .HasColumnName("Id_Tripulante_Persona").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Rut)
                        .HasColumnName("Rut");

            Property(s => s.Codigo_Strait)
                        .HasColumnName("Codigo_Strait");
            Property(s => s.Id_Azure)
                        .HasColumnName("Id_Azure").IsRequired();
            Property(s => s.Nombre)
                        .HasColumnName("Nombre").IsRequired();

            Property(s => s.Sindicato)
                        .HasColumnName("Sindicato");
            Property(s => s.Cargo)
                        .HasColumnName("Cargo");
            Property(s => s.Correo)
                        .HasColumnName("Correo");
            Property(s => s.Telefono)
                        .HasColumnName("Telefono");
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado");

            Property(s => s.dispositivoID).HasColumnName("dispositivo_ID").IsOptional();

            //mucho es a uno
            #region Id_Base
            Property(ot => ot.Id_Base)
                .HasColumnName("Id_Base")
                .IsRequired();

            HasRequired(rt => rt.Base)
                .WithMany(st => st.Tripulante_Persona)
                .HasForeignKey(r => r.Id_Base)
                .WillCascadeOnDelete(false);
            #endregion Id_Base


            //uno es a mucho
            #region Ausencia

            HasMany(st => st.Ausencias)
                .WithRequired(rt => rt.Tripulante_Persona)
                .HasForeignKey(rt => rt.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Ausencia

            #region viatico

            HasMany(st => st.Viaticos)
                .WithRequired(rt => rt.Tripulante_Persona)
                .HasForeignKey(rt => rt.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion viatico

            #region Tripulantes

            HasMany(st => st.Tripulantes)
                .WithRequired(rt => rt.Tripulante_Persona)
                .HasForeignKey(rt => rt.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Tripulantes

            #region Actividad

            HasMany(st => st.Actividades)
                .WithRequired(rt => rt.TripulantePersona)
                .HasForeignKey(rt => rt.Id_TripulantePersona)
                .WillCascadeOnDelete(false);

            #endregion Actividad



            #region Patio

            HasMany(st => st.Patios)
                .WithRequired(rt => rt.Tripulante_Persona)
                .HasForeignKey(rt => rt.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Patio

            //#region Pasajero

            //HasMany(st => st.Pasajeros)
            //    .WithRequired(rt => rt.Tripulante_Persona)
            //    .HasForeignKey(rt => rt.Id_Tripulante_Persona)
            //    .WillCascadeOnDelete(false);

            //#endregion Pasajero
        }
    }
}