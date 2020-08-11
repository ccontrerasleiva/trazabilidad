namespace Data.Entities
{
    using Data.Extensions;

    internal class Patio : BaseEntity<Domain.Models.Patio>
    {
        public Patio()
        {
            ToTable("TR_Patio");

            Property(s => s.Id)
                        .HasColumnName("Id_Patio").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Tipo)
                        .HasColumnName("Tipo").IsRequired();


            #region Id_Tripulante_Persona

            Property(ot => ot.Id_Tripulante_Persona)
                .HasColumnName("Id_Tripulante_Persona")
                .IsRequired();

            HasRequired(rt => rt.Tripulante_Persona)
                .WithMany(st => st.Patios)
                .HasForeignKey(r => r.Id_Tripulante_Persona)
                .WillCascadeOnDelete(false);

            #endregion Id_Tripulante_Persona

            #region Id_Tren

            Property(ot => ot.Id_Tren)
                .HasColumnName("Id_Tren")
                .IsRequired();

            HasRequired(rt => rt.Tren)
                .WithMany(st => st.Patios)
                .HasForeignKey(r => r.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Id_Tren

            #region Id_Base

            Property(ot => ot.Id_Base)
                .HasColumnName("Id_Base")
                .IsRequired();

            HasRequired(rt => rt.Base)
                .WithMany(st => st.Patios)
                .HasForeignKey(r => r.Id_Base)
                .WillCascadeOnDelete(false);

            #endregion Id_Base
        }
    }
}