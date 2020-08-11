namespace Data.Entities
{
    using Data.Extensions;

    internal class Programacion : BaseEntity<Domain.Models.Programacion>
    {
        public Programacion()
        {
            ToTable("TR_Programacion");

            Property(s => s.Id)
                .HasColumnName("Id_Programacion").IsRequired();

            Property(s => s.Dia)
                        .HasColumnName("Dia").IsRequired();
            Property(s => s.CodigoPlanificacion)
                        .HasColumnName("CodigoPlanificacion");
            Property(s => s.Tripulante)
                        .HasColumnName("Tripulante").IsRequired();
            Property(s => s.Real)
                        .HasColumnName("Real");
            Property(s => s.Pasajero)
                        .HasColumnName("Pasajero");
            Property(s => s.HoraPresentacion)
                        .HasColumnName("HoraPresentacion");
            Property(s => s.HoraTermino)
                        .HasColumnName("HoraTermino");
            Property(s => s.Pareja)
                .HasColumnName("Pareja").IsRequired();
            Property(s => s.Base)
                        .HasColumnName("Base").IsRequired();


        }
    }
}