
namespace Data.Entities
{
    using Data.Extensions;

    internal class ETConvoyCabecera : BaseEntity<Domain.Models.ETConvoyCabecera>
    {
        public ETConvoyCabecera()
        {
            ToTable("ET_Convoy_Cabecera");


            Property(s => s.Id)
                        .HasColumnName("IdEtConvoyCabecera").IsRequired();
            HasKey(be => be.Id);

            Property(s => s.CnvBseCod).HasColumnName("CnvBseCod").IsOptional();
            Property(s => s.CnvBasCod).HasColumnName("CnvBasCod").IsOptional();
            Property(s => s.CnvId).HasColumnName("CnvId").IsOptional();
            Property(s => s.CnvObs).HasColumnName("CnvObs").IsOptional();
            Property(s => s.CnvCicPesCod).HasColumnName("CnvCicPesCod").IsOptional();
            Property(s => s.CnvChoid).HasColumnName("CnvChoid").IsOptional();
            Property(s => s.CnvChoDid).HasColumnName("CnvChoDid").IsOptional();
            Property(s => s.CnvChoNom).HasColumnName("CnvChoNom").IsOptional();
            Property(s => s.IdCV).HasColumnName("IdCV").IsOptional();
        }
    }
}
