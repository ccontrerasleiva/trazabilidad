namespace Data.Entities
{
    using Data.Extensions;

    internal class Festivo : BaseEntity<Domain.Models.Festivo>
    {
        public Festivo()
        {
            ToTable("TM_Festivo");

            Property(s => s.Id)
                        .HasColumnName("Id_Festivo").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Fecha)
                        .HasColumnName("Fecha").IsRequired();
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion");
            //Property(s => s.Deshabilitado)
            //           .HasColumnName("Deshabilitado").IsRequired();

            //muchos a uno
            #region base
            Property(ot => ot.Id_Base)
                .HasColumnName("Id_Base")
                .IsRequired();

            HasRequired(rt => rt.Base)
                .WithMany(st => st.Festivo)
                .HasForeignKey(r => r.Id_Base)
                .WillCascadeOnDelete(false);
            #endregion

            //uno es a mucho
            #region Festivo_Estaciones

            HasMany(st => st.Festivo_Estacion)
                .WithRequired(rt => rt.Festivo)
                .HasForeignKey(rt => rt.Id_Festivo)
                .WillCascadeOnDelete(false);

            #endregion Festivo_Estaciones


        }
    }
}