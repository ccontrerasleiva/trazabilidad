
namespace Data.Entities
{
    using Data.Extensions;

    internal class PesoConvoy: BaseEntity<Domain.Models.PesoConvoy>
    {
        public PesoConvoy()
        {
            ToTable("ET_Convoy_Log_Service");


            Property(s => s.Id)
                        .HasColumnName("IdETConvoyLogService").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.IdETConvoyCabecera).HasColumnName("IdETConvoyCabecera").IsOptional();
            Property(s => s.Descripcion).HasColumnName("Descripcion").IsOptional();
            Property(s => s.Fecha).HasColumnName("Fecha").IsOptional();
            
        }
    }
}
