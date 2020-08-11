namespace Data.Entities
{
    using Data.Extensions;

    internal class Viatico : BaseEntity<Domain.Models.Viatico>
    {
        public Viatico()
        {
            ToTable("TR_Viatico");

            Property(s => s.Id)
                        .HasColumnName("Id_Viatico").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Tipo_Viatico)
                        .HasColumnName("Tipo_Viatico").IsRequired();
            Property(s => s.Fecha)
                        .HasColumnName("Fecha").IsRequired();

            //mucho es a uno
            #region Id_Tripulante_Persona

            Property(ot => ot.Id_Tripulante_Persona)
                .HasColumnName("Id_Tripulante_Persona")
                .IsRequired();

            HasRequired(rt => rt.Tripulante_Persona)
                .WithMany(st => st.Viaticos)
                .HasForeignKey(r => r.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante_Persona

            #region Trenes

            Property(ot => ot.Id_Tren)
                .HasColumnName("Id_Tren")
                .IsRequired();

            HasRequired(rt => rt.Tren)
                .WithMany(st => st.Viaticos)
                .HasForeignKey(r => r.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Trenes
        }
    }
}