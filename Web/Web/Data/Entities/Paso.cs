
namespace Data.Entities
{
    using Data.Extensions;

    internal class Paso : BaseEntity<Domain.Models.Paso>
    {
        public Paso()
        {
            ToTable("Paso");


            Property(s => s.Id)
                        .HasColumnName("Id").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Descripcion).HasColumnName("Descripcion");
            Property(s => s.Descripcion).HasColumnType("varchar");
            Property(s => s.Descripcion).HasMaxLength(50);

            

            //modelBuilder.Entity<IGArmado2>()
            //.Property(b => b.stop_time).HasMaxLength(50);

        }
    }
}
