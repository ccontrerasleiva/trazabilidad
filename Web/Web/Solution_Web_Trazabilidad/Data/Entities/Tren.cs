namespace Data.Entities
{
    using Data.Extensions;

    internal class Tren : BaseEntity<Domain.Models.Tren>
    {
        public Tren()
        {
            ToTable("TR_Tren");

            Property(s => s.Id)
                        .HasColumnName("Id_Tren").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Estado)
                        .HasColumnName("Estado").IsRequired();
            Property(s => s.Tren_Concatenado)
                        .HasColumnName("Tren_Concatenado");
            Property(s => s.Tipo)
                        .HasColumnName("Tipo").IsRequired();
            //Property(s => s.Hora_Inicio_Reprogramada)
            //            .HasColumnName("Hora_Inicio_Reprogramada").IsOptional();
            //Property(s => s.Hora_Final_Reprogramada)
            //           .HasColumnName("Hora_Final_Reprogramada").IsOptional();

            Property(s => s.Salida_Real)
                        .HasColumnName("Salida_Real")
.IsOptional();

            Property(s => s.Id_Informe_Tren)
                        .HasColumnName("Id_Informe_Tren")
.IsOptional();
            Property(s => s.Llegada_Real)
                        .HasColumnName("Llegada_Real")
.IsOptional();
            Property(s => s.Hora_Presentacion)
                        .HasColumnName("Hora_Presentacion");
            Property(s => s.Incumplimiento)
                        .HasColumnName("Incumplimiento")
.IsOptional();
            Property(s => s.VColacion)
                       .HasColumnName("VColacion").IsOptional();
            Property(s => s.VAlojamiento)
                       .HasColumnName("VAlojamiento").IsOptional();
            //Property(s => s.HoraTotal)
            //          .HasColumnName("HoraTotal").IsOptional();


            //mucho es a uno
            #region Id_Itinerario

            Property(ot => ot.Id_Itinerario)
                .HasColumnName("Id_Itinerario")
                .IsRequired();

            HasRequired(rt => rt.Itinerario)
                .WithMany(st => st.Tren)
                .HasForeignKey(r => r.Id_Itinerario)
                .WillCascadeOnDelete(false);

            #endregion Id_Itinerario

            //uno es a muchos

            #region tren_tramo

            HasMany(st => st.Tren_Tramos)
                .WithRequired(rt => rt.Tren)
                .HasForeignKey(rt => rt.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion tren_tramo

            #region patios

            HasMany(st => st.Patios)
                .WithRequired(rt => rt.Tren)
                .HasForeignKey(rt => rt.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion patios

            #region gps

            HasMany(st => st.Gps)
                .WithRequired(rt => rt.Tren)
                .HasForeignKey(rt => rt.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion gps

            #region Tren_Locomotoras

            HasMany(st => st.Tren_Locomotoras)
                .WithRequired(rt => rt.Tren)
                .HasForeignKey(rt => rt.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Tren_Locomotoras

            //#region Pasajeros

            //HasMany(st => st.Pasajeros)
            //    .WithRequired(rt => rt.Tren)
            //    .HasForeignKey(rt => rt.Id_Tren)
            //    .WillCascadeOnDelete(false);

            //#endregion Pasajeros

            #region Novedades

            HasMany(st => st.Novedades)
                .WithRequired(rt => rt.Tren)
                .HasForeignKey(rt => rt.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Novedades

            #region Viaticos

            HasMany(st => st.Viaticos)
                .WithRequired(rt => rt.Tren)
                .HasForeignKey(rt => rt.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Viaticos
        }
    }
}