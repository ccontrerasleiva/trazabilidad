
namespace Data.Entities
{
    using Data.Extensions;

    internal class Tag : BaseEntity<Domain.Models.Tag>
    {
        public Tag()
        {
            ToTable("Tag");


            Property(s => s.Id)
                        .HasColumnName("IdTag").IsRequired();
            HasKey(be => be.Id);
       
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion").IsRequired();
            

          
        }
    }
}
