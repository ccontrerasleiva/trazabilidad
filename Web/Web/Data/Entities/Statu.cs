
namespace Data.Entities
{
    using Data.Extensions;

    internal class Statu : BaseEntity<Domain.Models.Statu>
    {
        public Statu()
        {
            ToTable("Statu");


            Property(s => s.Id)
                        .HasColumnName("IdStatu").IsRequired();
            HasKey(be => be.Id);
       
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion").IsRequired();
            

          
        }
    }
}
