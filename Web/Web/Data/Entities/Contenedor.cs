
namespace Data.Entities
{
    using Data.Extensions;

    internal class Contenedor : BaseEntity<Domain.Models.Contenedor>
    {
        public Contenedor()
        {
            ToTable("Contenedor");


            Property(s => s.Id)
                        .HasColumnName("IdContenedor").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Descripcion) 
                        .HasColumnName("Descripcion").IsRequired();
            Property(s => s.PesoTara)
                        .HasColumnName("PesoTara").IsRequired();
            Property(s => s.Patente)
                        .HasColumnName("Patente").IsRequired();


                   }
    }
}
