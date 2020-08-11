namespace Data.Entities
{
    using Data.Extensions;

    internal class ReglasDeNegocio : BaseEntity<Domain.Models.ReglasDeNegocio>
    {
        public ReglasDeNegocio()
        {
            ToTable("TM_ReglasDeNegocio");

            Property(s => s.Id)
                           .HasColumnName("Id_ReglaDeNegocio").IsRequired();
            HasKey(be => be.Id);
            Property(s => s.Nombre)
                         .HasColumnName("Nombre").IsRequired();
            Property(s => s.Descripcion)
                        .HasColumnName("Descripcion").IsOptional();
            Property(s => s.Valor)
                       .HasColumnName("Valor").IsOptional();
            Property(s => s.Resultado)
                       .HasColumnName("Resultado").IsOptional();
            Property(s => s.Condicion)
                       .HasColumnName("Condicion").IsOptional();
            Property(s => s.Unidad)
                       .HasColumnName("Unidad").IsOptional();
            Property(s => s.Sindicato)
                       .HasColumnName("Sindicato").IsOptional();






        }
    }
}