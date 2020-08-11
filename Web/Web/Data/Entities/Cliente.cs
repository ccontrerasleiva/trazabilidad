
namespace Data.Entities
{
    using Data.Extensions;

    internal class Cliente : BaseEntity<Domain.Models.Cliente>
    {
        public Cliente()
        {
            ToTable("Cliente");


            Property(s => s.Id)
                        .HasColumnName("IdCliente").IsRequired();
            HasKey(be => be.Id);
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();
            Property(s => s.Nombre)
                        .HasColumnName("Nombre").IsRequired();
            Property(s => s.Celular)
                        .HasColumnName("Celular").IsRequired();




            #region Trazabilidad

            #region Cliente
            HasMany(st => st.TrazabilidadCliente)
               .WithRequired(rt => rt.DescripcionCliente)
               .HasForeignKey(rt => rt.IdCliente)
               .WillCascadeOnDelete(false);
            #endregion

            #endregion
        }
    }
}
