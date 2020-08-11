namespace Data.Entities
{
    using Data.Extensions;

    internal class Log : BaseEntity<Domain.Models.Log>
    {
        public Log()
        {
            ToTable("Log");

            Property(s => s.Id)
                           .HasColumnName("Id_Log").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Descripcion)
                           .HasColumnName("Descripcion");
            Property(s => s.Clase)
                           .HasColumnName("Clase").IsRequired();
            Property(s => s.Metodo)
                           .HasColumnName("Metodo").IsRequired();


        }
    }
}