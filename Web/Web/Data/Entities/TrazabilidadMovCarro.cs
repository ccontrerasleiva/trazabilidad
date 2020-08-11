
namespace Data.Entities
{
    using Data.Extensions;

    internal class TrazabilidadMovCarro : BaseEntity<Domain.Models.TrazabilidadMovCarro>
    {
        public TrazabilidadMovCarro()
        {
            ToTable("Trazabilidad_Mov_Carro");


            Property(s => s.Id)
                        .HasColumnName("IdTrazabilidadMovCarro").IsRequired();
            HasKey(be => be.Id);

            #region Trazabilidad
            Property(ot => ot.IdTrazabilidad)
                .HasColumnName("IdTrazabilidad")
                .IsRequired();


            HasRequired(rt => rt.Trazabilidad)
                .WithMany(sd => sd.TrazaMoviLoco_Carro)
                .HasForeignKey(r => r.IdTrazabilidad)
                .WillCascadeOnDelete(false);
            #endregion Trazabilidad

            #region Carro
            Property(ot => ot.IdCarro)
                .HasColumnName("IdCarro")
                .IsRequired();

            HasRequired(rt => rt.Carro)
                .WithMany(st => st.TrazaMovCarro_Carro)
                .HasForeignKey(r => r.IdCarro)
                .WillCascadeOnDelete(false);
            #endregion Carro

            #region Contenedor
            Property(ot => ot.IdContenedor)
                .HasColumnName("IdContenedor")
                .IsRequired();

            HasRequired(rt => rt.Contenedor)
                .WithMany(st => st.TrazaMovCarro_Contenedor)
                .HasForeignKey(r => r.IdContenedor)
                .WillCascadeOnDelete(false);
            #endregion Contenedor

            #region Status
            Property(ot => ot.IdStatusContenedor)
                .HasColumnName("IdStatu")
                .IsRequired();

            HasRequired(rt => rt.Statu)
                .WithMany(st => st.TrazaMovCarro_Statu)
                .HasForeignKey(r => r.IdStatusContenedor )
                .WillCascadeOnDelete(false);
            #endregion Status
            
            #region Tag
            Property(ot => ot.IdTag)
                .HasColumnName("IdTag")
                .IsRequired();

            HasRequired(rt => rt.Tag)
                .WithMany(st => st.TrazaMovCarro_Tag)
                .HasForeignKey(r => r.IdTag)
                .WillCascadeOnDelete(false);
            #endregion Tag

            Property(s => s.CodigoSello).HasColumnName("CodigoSello").IsOptional();
            Property(s => s.PesoNeto).HasColumnName("PesoNeto").IsOptional();
            Property(s => s.PesoBruto).HasColumnName("PesoBruto").IsOptional();
            Property(s => s.PesoTara).HasColumnName("PesoTara").IsOptional();
            Property(s => s.Sello).HasColumnName("Sello").IsOptional();


        }
    }
}
