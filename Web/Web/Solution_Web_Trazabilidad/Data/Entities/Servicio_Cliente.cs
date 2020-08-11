
namespace Data.Entities
{
    using Data.Extensions;

    internal class Servicio_Cliente : BaseEntity<Domain.Models.Servicio_Cliente>
    {
        public Servicio_Cliente()
        {
            ToTable("TR_Servicio_Cliente");


            Property(s => s.Id)
                        .HasColumnName("Id_Servicio_Cliente").IsRequired();
            HasKey(be => be.Id);



            //mucho es a uno
            #region Id_Servicio

            Property(ot => ot.Id_Servicio)
                .HasColumnName("Id_Servicio")
                .IsRequired();

            HasRequired(rt => rt.Servicio)
                .WithMany(st => st.Servicios_Cliente)
                .HasForeignKey(r => r.Id_Servicio)
                .WillCascadeOnDelete(false);

            #endregion Id_Servicio

            #region Id_Cliente

            Property(ot => ot.Id_Cliente)
                .HasColumnName("Id_Cliente")
                .IsRequired();

            HasRequired(rt => rt.Cliente)
                .WithMany(st => st.Servicios_Cliente)
                .HasForeignKey(r => r.Id_Cliente)
                .WillCascadeOnDelete(false);

            #endregion Id_Cliente
        }
    }
}
