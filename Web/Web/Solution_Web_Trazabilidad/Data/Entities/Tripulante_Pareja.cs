namespace Data.Entities
{
    using Data.Extensions;

    internal class Tripulante_Pareja : BaseEntity<Domain.Models.Tripulante_Pareja>
    {
        public Tripulante_Pareja()
        {
            ToTable("TR_Tripulante_Pareja");

            Property(s => s.Id_Tripulante_Persona)
                        .HasColumnName("Id_Tripulante_Persona").IsRequired();
            Property(s => s.Id_Tripulante_Persona2)
                        .HasColumnName("Id_Tripulante_Persona2").IsRequired();

            #region Id_Tripulante_Persona

            Property(ot => ot.Id_Tripulante_Persona)
                .HasColumnName("Id_Tripulante_Persona")
                .IsRequired();

            HasRequired(rt => rt.Tripulante_Persona)
                .WithMany(st => st.Tripulante_Pareja)
                .HasForeignKey(r => r.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante_Persona

        }
    }
}