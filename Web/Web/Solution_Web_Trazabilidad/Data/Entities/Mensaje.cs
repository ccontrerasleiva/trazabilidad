namespace Data.Entities
{
    using Data.Extensions;

    internal class Mensaje : BaseEntity<Domain.Models.Mensaje>
    {
        public Mensaje()
        {
            ToTable("TM_Mensaje");

            Property(s => s.Id)
                           .HasColumnName("Id_Mensaje").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Descripccion)
                          .HasColumnName("Descripccion").IsOptional();
            Property(s => s.Tag)
                           .HasColumnName("Tag").IsOptional();
            Property(s => s.Codigo)
                           .HasColumnName("Codigo").IsOptional();


        }
    }
}