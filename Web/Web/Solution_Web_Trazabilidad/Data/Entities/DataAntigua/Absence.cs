namespace Data.Entities
{
    using Data.Extensions;
    //
    internal class Absence : BaseEntity<Domain.Models.Absence>
    {
        public Absence()
        {
            ToTable("Ausencias");

            Property(abs => abs.StartDate)
                .HasColumnName("fecha_inicio")
                .IsRequired();

            Property(abs => abs.EndDate)
                .HasColumnName("fecha_finalizacion")
                .IsRequired();

            Property(abs => abs.UserId)
                .HasColumnName("id_usuario_azure")
                .IsRequired();

            #region Reason

            Property(abs => abs.ReasonId)
                .HasColumnName("id_motivo_ausencia")
                .IsRequired();

            HasRequired(abs => abs.Reason)
                .WithMany(reason => reason.Absences)
                .HasForeignKey(abs => abs.ReasonId)
                .WillCascadeOnDelete(false);

            #endregion Reason
        }
    }
}