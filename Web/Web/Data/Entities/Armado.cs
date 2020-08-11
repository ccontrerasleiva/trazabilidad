
namespace Data.Entities
{
    using Data.Extensions;

    internal class Armado : BaseEntity<Domain.Models.Armado>
    {
        public Armado()
        {
            ToTable("IG_Armado");


            Property(s => s.Id)
                        .HasColumnName("IdIGArmado").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.stop_time).HasColumnName("stop-time");
            Property(s => s.stop_time).HasColumnType("varchar");
            Property(s => s.stop_time).HasMaxLength(50);

            Property(s => s.stop_event).HasColumnName("stop-event");
            Property(s => s.stop_event).HasColumnType("varchar");
            Property(s => s.stop_event).HasMaxLength(50);

            Property(s => s.start_time).HasColumnName("start-time");
            Property(s => s.start_time).HasColumnType("varchar");
            Property(s => s.start_time).HasMaxLength(50);

            Property(s => s.start_event).HasColumnName("start-event");
            Property(s => s.start_event).HasColumnType("varchar");
            Property(s => s.start_event).HasMaxLength(100);

            Property(s => s.condition).HasColumnName("condition");
            Property(s => s.condition).HasColumnType("varchar");
            Property(s => s.condition).HasMaxLength(50);

            Property(s => s.locationId).HasColumnName("locationId");
            Property(s => s.locationId).HasColumnType("varchar");
            Property(s => s.locationId).HasMaxLength(10);

            Property(s => s.tag_count).HasColumnName("tag-count");
            Property(s => s.tag_count).HasColumnType("varchar");
            Property(s => s.tag_count).HasMaxLength(10);

            Property(s => s.type).HasColumnName("type");
            Property(s => s.type).HasColumnType("varchar");
            Property(s => s.type).HasMaxLength(100);

            Property(s => s.objectId).HasColumnName("objectId");
            Property(s => s.objectId).HasColumnType("varchar");
            Property(s => s.objectId).HasMaxLength(100);

            Property(s => s.drivers).HasColumnName("drivers");
            Property(s => s.drivers).HasColumnType("varchar");
            Property(s => s.drivers).HasMaxLength(100);

            Property(s => s.status).HasColumnName("status");
            Property(s => s.status).HasColumnType("varchar");
            Property(s => s.status).HasMaxLength(100);

            Property(s => s.timestamp).HasColumnName("timestamp");
            Property(s => s.timestamp).HasColumnType("varchar");
            Property(s => s.timestamp).HasMaxLength(50);

            Property(s => s.UUID).HasColumnName("UUID");

            Property(s => s.Procesado).HasColumnName("Procesado");

            Property(s => s.Fecha).HasColumnName("Fecha");

            //modelBuilder.Entity<IGArmado2>()
            //.Property(b => b.stop_time).HasMaxLength(50);

        }
    }
}
