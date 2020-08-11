namespace Data.Entities
{
    using Data.Extensions;

    internal class Novedad : BaseEntity<Domain.Models.Novedad>
    {
        public Novedad()
        {
            ToTable("TR_Novedad");

            Property(s => s.Id)
                           .HasColumnName("Id_Novedad").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Tipo)
                           .HasColumnName("Tipo").IsRequired();
            Property(s => s.Descripcion)
                           .HasColumnName("Descripcion");
            Property(s => s.Reportado_Por)
                           .HasColumnName("Reportado_Por");


            #region Id_Tren

            Property(ot => ot.Id_Tren)
                .HasColumnName("Id_Tren")
                .IsRequired();


            HasRequired(rt => rt.Tren)
                .WithMany(st => st.Novedades)
                .HasForeignKey(r => r.Id_Tren)
                .WillCascadeOnDelete(false);

            #endregion Id_Tren

            #region Id_Servicio

            Property(ot => ot.Id_Servicio)
                .HasColumnName("Id_Servicio")
                .IsRequired();

            HasRequired(rt => rt.Servicio)
                .WithMany(st => st.Novedadades)
                .HasForeignKey(r => r.Id_Servicio)
                .WillCascadeOnDelete(false);

            #endregion Id_Servicio
        }
    }
}