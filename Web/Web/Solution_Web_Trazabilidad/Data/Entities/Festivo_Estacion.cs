namespace Data.Entities
{
    using Data.Extensions;

    internal class Festivo_Estacion : BaseEntity<Domain.Models.Festivo_Estacion>
    {
        public Festivo_Estacion()
        {
            ToTable("TR_Festivo_Estacion");

            Property(s => s.Id)
                        .HasColumnName("Id_Festivo_Estacion").IsRequired();
            HasKey(be => be.Id);


            #region EstacionId

            Property(ot => ot.Id_Estacion)
                .HasColumnName("Id_Estacion")
                .IsRequired();

            HasRequired(rt => rt.Estacion)
                .WithMany(st => st.Festivo_Estacion)
                .HasForeignKey(r => r.Id_Estacion)
                .WillCascadeOnDelete(false);

            #endregion EstacionId

            #region FestivoId

            Property(ot => ot.Id_Festivo)
                .HasColumnName("Id_Festivo")
                .IsRequired();

            HasRequired(rt => rt.Festivo)
                .WithMany(st => st.Festivo_Estacion)
                .HasForeignKey(r => r.Id_Festivo)
                .WillCascadeOnDelete(false);

            #endregion FestivoId
        }
    }
}