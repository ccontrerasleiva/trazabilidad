
namespace Data.Entities
{
    using Data.Extensions;

    internal class Carro : BaseEntity<Domain.Models.Carro>
    {
        public Carro()
        {
            ToTable("Carro");


            Property(s => s.Id)
                        .HasColumnName("IdCarro").IsRequired();
            HasKey(be => be.Id);
       
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion").IsRequired();
            Property(s => s.Patente)
                        .HasColumnName("Patente").IsRequired();


          
        }
    }
}
