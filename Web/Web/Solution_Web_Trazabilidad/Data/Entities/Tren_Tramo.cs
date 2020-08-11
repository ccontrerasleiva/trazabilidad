namespace Data.Entities
{
    using System;
    using Data.Extensions;
    using System.ComponentModel.DataAnnotations;

    internal class Tren_Tramo : BaseEntity<Domain.Models.Tren_Tramo>
    {
        public Tren_Tramo()
        {
            ToTable("TR_Tren_Tramo");

            Property(s => s.Id)
                       .HasColumnName("Id_Tren_Tramo").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Hora_Salida_Real)
                        .HasColumnName("Hora_Salida_Real");
            Property(s => s.Tiempo_Acumulado)
                        .HasColumnName("Tiempo_Acumulado").IsOptional();
            Property(s => s.Hora_Llegada_Real)
                        .HasColumnName("Hora_Llegada_Real").IsOptional();

            //mucho es a uno
            #region Destination

            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsRequired();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.Tren_TramoD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);

            #endregion Destination

            #region Origin

            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsRequired();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.Tren_TramoO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);

            #endregion Origin

            #region Id_Tren

            Property(ot => ot.Id_Tren)
                .HasColumnName("Id_Tren")
                .IsRequired();

            HasRequired(rt => rt.Tren)
                .WithMany(st => st.Tren_Tramos)
                .HasForeignKey(r => r.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Id_Tren

            #region Id_Tramo

            Property(ot => ot.Id_Tramo)
                .HasColumnName("Id_Tramo")
                .IsRequired();

            HasRequired(rt => rt.Tramo)
                .WithMany(st => st.Tren_Tramo)
                .HasForeignKey(r => r.Id_Tramo)
                .WillCascadeOnDelete(false);

            #endregion Id_Tramo
            //uno es a muchos
            #region H_Tren_Tramo

            //HasMany(st => st.Tarea_Patio)
            //    .WithRequired(rt => rt.Itinerario)
            //    .HasForeignKey(rt => rt.Id_Itinerario)
            //    .WillCascadeOnDelete(false);

            #endregion H_Tren_Tramo
        }



    }
}