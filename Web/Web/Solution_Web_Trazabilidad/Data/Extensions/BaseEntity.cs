namespace Data.Extensions
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// Clase base para las entidades. Hereda de <see cref="EntityTypeConfiguration{Domain.Extensions.BaseModel}"/>
    /// con el fin de no tener que repetir la configuración de las propiedades para sus respectivas implementaciones.
    /// </summary>
    /// <typeparam name="T">Clase que hereda de <see cref="Domain.Models.BaseModel"/></typeparam>
    internal class BaseEntity<T> : EntityTypeConfiguration<T> where T : Domain.Extensions.BaseModel
    {
        public BaseEntity()
        {
            //Property(a => a.Id)
            //    .HasColumnName("id");

            //HasKey(be => be.Id);

            Property(be => be.Created)
                .HasColumnName("fecha_creacion")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();

            Property(be => be.Updated)
                .HasColumnName("fecha_modificacion")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(be => be.Deshabilitado)
                .HasColumnName("Deshabilitado")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsOptional();
        }
    }
}