namespace Data.Entities
{
    using Data.Extensions;

    internal class Tarea_Patio : BaseEntity<Domain.Models.Tarea_Patio>
    {
        public Tarea_Patio()
        {
            ToTable("TM_Tarea_Patio");

            Property(s => s.Id)
                        .HasColumnName("Id_Tarea_Patio").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Hora_Inicio)
                        .HasColumnName("Hora_Inicio").IsRequired();
            Property(s => s.Hora_Fin)
                        .HasColumnName("Hora_Fin").IsRequired();

            //mucho es a uno
            #region Id_Itinerario

            Property(ot => ot.Id_Itinerario)
                .HasColumnName("Id_Itinerario")
                .IsRequired();

            HasRequired(rt => rt.Itinerario)
                .WithMany(st => st.Tarea_Patio)
                .HasForeignKey(r => r.Id_Itinerario)
                .WillCascadeOnDelete(false);

            #endregion Id_Itinerario
        }
    }
}