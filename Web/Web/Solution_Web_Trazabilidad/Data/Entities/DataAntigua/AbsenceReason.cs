namespace Data.Entities
{
    using Data.Extensions;
    //
    internal class AbsenceReason : BaseEntity<Domain.Models.AbsenceReason>
    {
        public AbsenceReason()
        {
            ToTable("MotivoAusencias");

            Property(abs => abs.Code)
                .HasColumnName("codigo")
                .IsRequired();

            Property(abs => abs.Description)
                .HasColumnName("descripcion")
                .IsRequired();
        }
    }
}