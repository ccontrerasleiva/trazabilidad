
namespace Data.Entities
{
    using Data.Extensions;

    internal class IGLogArmado : BaseEntity2<Domain.Models.IGLogArmado>
    {
        public IGLogArmado()
        {
            ToTable("IG_Log_Armado");


            Property(s => s.Id)
                        .HasColumnName("IdIGLog").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.Texto).HasColumnName("Texto");

            Property(s => s.Estado).HasColumnName("Estado");

            Property(s => s.Descripcion_Estado).HasColumnName("Descripcion_Estado");

            Property(s => s.Fecha).HasColumnName("Fecha");

            //modelBuilder.Entity<IGArmado2>()
            //.Property(b => b.stop_time).HasMaxLength(50);

        }
    }
}
