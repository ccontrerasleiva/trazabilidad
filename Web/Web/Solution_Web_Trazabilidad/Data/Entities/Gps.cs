namespace Data.Entities
{
    using Data.Extensions;

    internal class Gps : BaseEntity<Domain.Models.Gps>
    {
        public Gps()
        {
            ToTable("TR_Gps");

            Property(s => s.Id)
                        .HasColumnName("Id_Gps").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Latitud).HasColumnType("decimal").HasPrecision(18, 15)
                        .HasColumnName("Latitud").IsRequired();
            Property(s => s.Longitud).HasColumnType("decimal").HasPrecision(18, 15)
                        .HasColumnName("Longitud").IsRequired();
            Property(s => s.Fecha_Envio)
                        .HasColumnName("Fecha_Envio").IsOptional();



            #region Id_Tren

            Property(ot => ot.Id_Tren)
                .HasColumnName("Id_Tren")
                .IsRequired();

            HasRequired(rt => rt.Tren)
                .WithMany(st => st.Gps)
                .HasForeignKey(r => r.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Id_Tren
        }
    }
}