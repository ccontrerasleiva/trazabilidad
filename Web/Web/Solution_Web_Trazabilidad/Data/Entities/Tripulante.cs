namespace Data.Entities
{
    using Data.Extensions;

    internal class Tripulante : BaseEntity<Domain.Models.Tripulante>
    {
        public Tripulante()
        {
            ToTable("TR_Tripulante");

            Property(s => s.Id)
                        .HasColumnName("Id_Tripulante").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Rol)
                        .HasColumnName("Rol");
            Property(s => s.Ausente)
                        .HasColumnName("Ausente").IsOptional();
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsOptional();

            //muchos a uno

            #region Destination

            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsRequired();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.TripulanteD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);

            #endregion Destination

            #region Origin

            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsRequired();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.TripulanteO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);

            #endregion Origin


            #region Id_Tripulante_Persona

            Property(ot => ot.Id_Tripulante_Persona)
               .HasColumnName("Id_Tripulante_Persona")
               .IsRequired();

            HasRequired(rt => rt.Tripulante_Persona)
                .WithMany(st => st.Tripulantes)
                .HasForeignKey(r => r.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante_Persona


            #region Id_Tren_Locomotora

            Property(ot => ot.Id_Tren_Locomotora)
                .HasColumnName("Id_Tren_Locomotora")
                .IsRequired();

            HasRequired(rt => rt.Tren_Locomotora)
                .WithMany(st => st.Tripulantes)
                .HasForeignKey(r => r.Id_Tren_Locomotora)
                .WillCascadeOnDelete(false);

            #endregion Id_Tren_Locomotora


            //uno es a mucho
            #region Actividad

            HasMany(st => st.Actividades)
                .WithRequired(rt => rt.Tripulante)
                .HasForeignKey(rt => rt.Id_Tripulante)
                .WillCascadeOnDelete(false);

            #endregion Actividad

            //#region HapaTripulante

            //HasMany(st => st.HapaTripulantes)
            //    .WithRequired(rt => rt.Tripulante)
            //    .HasForeignKey(rt => rt.Id_Tripulante)
            //    .WillCascadeOnDelete(false);

            //#endregion HapaTripulante
        }
    }
}