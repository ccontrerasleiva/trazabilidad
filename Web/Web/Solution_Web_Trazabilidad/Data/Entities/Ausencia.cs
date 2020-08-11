namespace Data.Entities
{
    using Data.Extensions;

    internal class Ausencia : BaseEntity<Domain.Models.Ausencia>
    {
        public Ausencia()
        {
            ToTable("TR_Ausencia");

            Property(s => s.Id)
                           .HasColumnName("Id_Ausencia").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Fecha_Inicio)
                           .HasColumnName("Fecha_Inicio");
            Property(s => s.Fecha_Fin)
                           .HasColumnName("Fecha_Fin");
            Property(s => s.Motivo)
                           .HasColumnName("Motivo");


            #region Id_Tripulante_Persona

            Property(ot => ot.Id_Tripulante_Persona)
                .HasColumnName("Id_Tripulante_Persona")
                .IsRequired();

            HasRequired(rt => rt.Tripulante_Persona)
                .WithMany(st => st.Ausencias)
                .HasForeignKey(r => r.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante_Persona
        }
    }
}