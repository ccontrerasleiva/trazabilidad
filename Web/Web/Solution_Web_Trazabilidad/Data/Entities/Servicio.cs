
namespace Data.Entities
{
    using Data.Extensions;

    internal class Servicio : BaseEntity<Domain.Models.Servicio>
    {
        public Servicio()
        {
            ToTable("TM_Servicio");


            Property(s => s.Id)
                        .HasColumnName("Id_Servicio").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Descripcion)
                .HasColumnName("Descripcion").IsRequired();
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();
            Property(s => s.Codigo)
                        .HasColumnName("Codigo").IsRequired();
            Property(s => s.Responsable)
                        .HasColumnName("Responsable").IsRequired();
            //Property(s => s.Id_Servicio_Cliente)
            //            .HasColumnName("Id_Servicio_Cliente").IsOptional();
            Property(s => s.VColacion)
                       .HasColumnName("VColacion").IsOptional();
            Property(s => s.VAlojamiento)
                       .HasColumnName("VAlojamiento").IsOptional();
            //Property(s => s.Bonificable)
            //            .HasColumnName("Bonificable").IsRequired();




            //uno es a mucho
            #region Servicios_Cliente

            HasMany(st => st.Servicios_Cliente)
                .WithRequired(rt => rt.Servicio)
                .HasForeignKey(rt => rt.Id_Servicio)
                .WillCascadeOnDelete(false);

            #endregion Servicios_Cliente

            #region Itinerario

            HasMany(st => st.Itinerario)
                .WithRequired(rt => rt.Servicio)
                .HasForeignKey(rt => rt.Id_Servicio)
                .WillCascadeOnDelete(false);

            #endregion Itinerario

            #region Novedad

            HasMany(st => st.Novedadades)
                .WithRequired(rt => rt.Servicio)
                .HasForeignKey(rt => rt.Id_Servicio)
                .WillCascadeOnDelete(false);

            #endregion Novedad
        }
    }
}
