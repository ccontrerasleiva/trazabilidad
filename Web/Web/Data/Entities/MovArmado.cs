
namespace Data.Entities
{
    using Data.Extensions;

    internal class MovArmado : BaseEntity<Domain.Models.MovArmado>
    {
        public MovArmado()
        {
            ToTable("IG_Mov_Armado");


            Property(s => s.Id)
                        .HasColumnName("IdIG_Mov_Armado").IsRequired();
            HasKey(be => be.Id);

            #region Armado
            Property(ot => ot.IdIGArmado)
                .HasColumnName("IdIGArmado")
                .IsRequired();

                HasRequired(rt => rt.Armado)
                .WithMany(sd => sd.ArmadoMovimiento)
                .HasForeignKey(r => r.IdIGArmado)
                .WillCascadeOnDelete(false);
            #endregion Armado

            Property(s => s.last_read).HasColumnName("last-read");
            Property(s => s.last_read).HasColumnType("varchar");
            Property(s => s.last_read).HasMaxLength(50);

            Property(s => s.observationUUID).HasColumnName("observationUUID");
            Property(s => s.observationUUID).HasColumnType("varchar");
            Property(s => s.observationUUID).HasMaxLength(200);

            Property(s => s.locationId).HasColumnName("locationId");
            Property(s => s.locationId).HasColumnType("varchar");
            Property(s => s.locationId).HasMaxLength(50);

            Property(s => s.reads).HasColumnName("reads");
            Property(s => s.reads).HasColumnType("varchar");
            Property(s => s.reads).HasMaxLength(50);

            Property(s => s.companyPrefix).HasColumnName("companyPrefix");
            Property(s => s.companyPrefix).HasColumnType("varchar");
            Property(s => s.companyPrefix).HasMaxLength(50);

            Property(s => s.itemReference).HasColumnName("itemReference");
            Property(s => s.itemReference).HasColumnType("varchar");
            Property(s => s.itemReference).HasMaxLength(50);

            Property(s => s.filterValue).HasColumnName("filterValue");
            Property(s => s.filterValue).HasColumnType("varchar");
            Property(s => s.filterValue).HasMaxLength(50);

            Property(s => s.serialNumber).HasColumnName("serialNumber");
            Property(s => s.serialNumber).HasColumnType("varchar");
            Property(s => s.serialNumber).HasMaxLength(50);

            Property(s => s.first_read).HasColumnName("first-read");
            Property(s => s.first_read).HasColumnType("varchar");
            Property(s => s.first_read).HasMaxLength(50);

            Property(s => s.type).HasColumnName("type");
            Property(s => s.type).HasColumnType("varchar");
            Property(s => s.type).HasMaxLength(100);

            Property(s => s.objectId).HasColumnName("objectId");
            Property(s => s.objectId).HasColumnType("varchar");
            Property(s => s.objectId).HasMaxLength(200);

            Property(s => s.timestamp).HasColumnName("timestamp");
            Property(s => s.timestamp).HasColumnType("varchar");
            Property(s => s.timestamp).HasMaxLength(50);

            Property(s => s.UUID).HasColumnName("UUID");


        //modelBuilder.Entity<IGArmado2>()
        //.Property(b => b.stop_time).HasMaxLength(50);

    }
    }
}
