namespace Data.Entities
{
    using Data.Extensions;

    internal class Tren_Locomotora : BaseEntity<Domain.Models.Tren_Locomotora>
    {
        public Tren_Locomotora()
        {
            ToTable("TR_Tren_Locomotora");

            Property(s => s.Id)
                        .HasColumnName("Id_Tren_Locomotora").IsRequired();
            HasKey(be => be.Id);
            //Property(s => s.Deshabilitado)
            //            .HasColumnName("Deshabilitado").IsRequired();
            Property(s => s.Estado)
                        .HasColumnName("Estado").IsRequired();
            Property(s => s.Principal)
                        .HasColumnName("Principal");
            Property(s => s.Familia)
                        .HasColumnName("Familia").IsRequired();



            //mucho es a uno
            #region Destination

            Property(ot => ot.Id_Destino)
                .HasColumnName("Id_Destino")
                .IsRequired();

            HasRequired(rt => rt.Destino)
                .WithMany(st => st.Tren_LocomotoraD)
                .HasForeignKey(r => r.Id_Destino)
                .WillCascadeOnDelete(false);

            #endregion Destination

            #region Origin

            Property(ot => ot.Id_Origen)
                .HasColumnName("Id_Origen")
                .IsRequired();

            HasRequired(rt => rt.Origen)
                .WithMany(st => st.Tren_LocomotoraO)
                .HasForeignKey(r => r.Id_Origen)
                .WillCascadeOnDelete(false);

            #endregion Origin

            #region Id_Locomotora

            Property(ot => ot.Id_Locomotora)
                .HasColumnName("Id_Locomotora")
                .IsRequired();

            HasRequired(rt => rt.Locomotora)
                .WithMany(st => st.Tren_Locomotoras)
                .HasForeignKey(r => r.Id_Locomotora)
                .WillCascadeOnDelete(false);

            #endregion Id_Locomotora

            #region Id_Tren

            Property(tr => tr.Id_Tren)
                .HasColumnName("Id_Tren")
                .IsRequired();

            HasRequired(tr => tr.Tren)
                .WithMany(ti => ti.Tren_Locomotoras)
                .HasForeignKey(ti => ti.Id_Tren)
                .WillCascadeOnDelete(false);


            #endregion Id_Tren

            //uno es a muchos
            #region tripulantes

            HasMany(st => st.Tripulantes)
                .WithRequired(rt => rt.Tren_Locomotora)
                .HasForeignKey(rt => rt.Id_Tren_Locomotora)
                .WillCascadeOnDelete(false);

            #endregion tripulantes
        }
    }
}