
namespace Data.Entities
{
    using Data.Extensions;

    internal class Estacion : BaseEntity<Domain.Models.Estacion>
    {
        public Estacion()
        {
            ToTable("TM_Estacion");


            Property(s => s.Id)
                        .HasColumnName("Id_Estacion").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.X_Mapa_Virtual)
                        .HasColumnName("X_Mapa_Virtual");
            Property(s => s.Y_Mapa_Virtual)
                        .HasColumnName("Y_Mapa_Virtual");
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();
            Property(s => s.Codigo)
                        .HasColumnName("Codigo").IsRequired();
            Property(s => s.Nombre)
                        .HasColumnName("Nombre").IsRequired();
            Property(s => s.Punto_Kilometraje)
                        .HasColumnName("Punto_Kilometraje").IsRequired();
            Property(s => s.Tipo)
                        .HasColumnName("Tipo");
            Property(s => s.Coordenadas_Area)
                        .HasColumnName("Coordenadas_Area");
            Property(s => s.Codigo_Recorrido)
                        .HasColumnName("Codigo_Recorrido");
            Property(s => s.Bifurcacion)
                        .HasColumnName("Bifurcacion");

            //mucho es a uno


            //uno es a mucho

            #region itinerario
            #region Origen
            HasMany(st => st.ItinerarioO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.ItinerarioD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Ruta

            #region itinerario
            #region Origen
            HasMany(st => st.RutaO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.RutaD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Ruta

            #region Tramo
            #region Origen
            HasMany(st => st.TramoO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.TramoD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Actividad

            #region Actividad
            #region Origen
            HasMany(st => st.ActividadO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.ActividadD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Actividad

            #region Tren Tramo
            #region Origen
            HasMany(st => st.Tren_TramoO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.Tren_TramoD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Tren Tramo

            //#region Pasajero
            //#region Origen
            //HasMany(st => st.PasajeroO)
            //   .WithRequired(rt => rt.Origen)
            //   .HasForeignKey(rt => rt.Id_Origen)
            //   .WillCascadeOnDelete(false);
            //#endregion

            //#region destino
            //HasMany(st => st.PasajeroD)
            //   .WithRequired(rt => rt.Destino)
            //   .HasForeignKey(rt => rt.Id_Destino)
            //   .WillCascadeOnDelete(false);
            //#endregion

            //#endregion Pasajero

            #region Tren Locomotora
            #region Origen
            HasMany(st => st.Tren_LocomotoraO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.Tren_LocomotoraD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Tren Locomotora

            #region Jornada
            #region Origen
            HasMany(st => st.JornadaO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.JornadaD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Jornada

            #region Tripulante
            #region Origen
            HasMany(st => st.TripulanteO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.TripulanteD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Tripulante

            #region Tiempo Hapa
            #region Origen
            HasMany(st => st.Tiempo_HapaO)
               .WithRequired(rt => rt.Origen)
               .HasForeignKey(rt => rt.Id_Origen)
               .WillCascadeOnDelete(false);
            #endregion

            #region destino
            HasMany(st => st.Tiempo_HapaD)
               .WithRequired(rt => rt.Destino)
               .HasForeignKey(rt => rt.Id_Destino)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion Tiempo Hapa

            #region Tripulante Persona
            HasMany(st => st.Tripulante_Persona)
              .WithRequired(rt => rt.Base)
              .HasForeignKey(rt => rt.Id_Base)
              .WillCascadeOnDelete(false);

            #endregion Tripulante Persona

            #region Festivo Estacion
            HasMany(st => st.Festivo_Estacion)
              .WithRequired(rt => rt.Estacion)
              .HasForeignKey(rt => rt.Id_Estacion)
              .WillCascadeOnDelete(false);

            #endregion Festivo Estacion

            #region Festivo 
            HasMany(st => st.Festivo)
              .WithRequired(rt => rt.Base)
              .HasForeignKey(rt => rt.Id_Base)
              .WillCascadeOnDelete(false);

            #endregion Festivo 
        }
    }
}
