
namespace Data.Entities
{
    using Data.Extensions;

    internal class HapaTripulante : BaseEntity<Domain.Models.HapaTripulante>
    {
        public HapaTripulante()
        {
            ToTable("TR_Hapa_Tripulante");


            Property(s => s.Id)
                        .HasColumnName("Id_Hapa_Tripulante").IsRequired();
            HasKey(be => be.Id);


            #region Hapas
            Property(ot => ot.Id_Hapa)
                .HasColumnName("Id_Tiempo_Hapa")
                .IsOptional();

            HasRequired(rt => rt.Hapa)
                .WithMany(st => st.HapaTripulantes)
                .HasForeignKey(r => r.Id_Hapa)
                .WillCascadeOnDelete(false);
            #endregion

            //#region Tripulantes
            //Property(ot => ot.Id_Tripulante)
            //    .HasColumnName("Id_Tripulante")
            //    .IsOptional();

            //HasRequired(rt => rt.Tripulante)
            //    .WithMany(st => st.HapaTripulantes)
            //    .HasForeignKey(r => r.Id_Tripulante)
            //    .WillCascadeOnDelete(false);
            //#endregion

            #region Actividad
            Property(ot => ot.Id_Actividad)
                .HasColumnName("Id_Actividad")
                .IsOptional();

            HasRequired(rt => rt.Actividad)
                .WithMany(st => st.HapaTripulantes)
                .HasForeignKey(r => r.Id_Actividad)
                .WillCascadeOnDelete(false);
            #endregion
        }
    }
}
