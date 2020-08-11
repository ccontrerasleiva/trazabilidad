namespace Data.Entities
{
    using Data.Extensions;

    internal class Tiempo_Hapa : BaseEntity<Domain.Models.Tiempo_Hapa>
    {
        public Tiempo_Hapa()
        {
            ToTable("TM_Tiempo_Hapa");

            Property(s => s.Id)
                        .HasColumnName("Id_Tiempo_Hapa").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Tiempo_Viaje)
                        .HasColumnName("Tiempo_Viaje");
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado");
            Property(s => s.TiempoRetorno)
                      .HasColumnName("TiempoRetorno").IsRequired();

            //mucho es a uno
            #region Destination
            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsRequired();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.Tiempo_HapaD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);
            #endregion

            #region Origin
            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsRequired();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.Tiempo_HapaO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);
            #endregion



            //uno  es a mucho

            //#region Pasajero

            //HasMany(st => st.Pasajeros)
            //    .WithRequired(rt => rt.Tiempo_Hapa)
            //    .HasForeignKey(rt => rt.Id_Tiempo_Hapa)
            //    .WillCascadeOnDelete(false);

            //#endregion Pasajero

            #region HapaTripulante

            HasMany(st => st.HapaTripulantes)
                .WithRequired(rt => rt.Hapa)
                .HasForeignKey(rt => rt.Id_Hapa)
                .WillCascadeOnDelete(false);

            #endregion Pasajero
        }
    }
}