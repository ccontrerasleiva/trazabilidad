namespace Data.Entities
{
    using Data.Extensions;

    internal class Tramo : BaseEntity<Domain.Models.Tramo>
    {
        public Tramo()
        {
            ToTable("TM_Tramo");

            Property(s => s.Id)
                        .HasColumnName("Id_Tramo").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Tiempo_Viaje)
                        .HasColumnName("Tiempo_Viaje").IsRequired();

            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();
            Property(s => s.Orden)
                       .HasColumnName("Orden").IsOptional();
            Property(s => s.TiempoRetorno)
                       .HasColumnName("TiempoRetorno").IsRequired();



            //mucho es a uno

            #region Destination

            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsRequired();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.TramoD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);

            #endregion Destination

            #region Origin

            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsRequired();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.TramoO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);

            #endregion Origin

            //uno es a muchos
            #region tramo Itinerario

            HasMany(st => st.Tramo_Itinerario)
                .WithRequired(rt => rt.Tramo)
                .HasForeignKey(rt => rt.Id_Tramo)
                .WillCascadeOnDelete(false);

            #endregion tarea Patio

            #region tren tramo

            HasMany(st => st.Tren_Tramo)
                .WithRequired(rt => rt.Tramo)
                .HasForeignKey(rt => rt.Id_Tramo)
                .WillCascadeOnDelete(false);

            #endregion tren tramo
        }
    }
}