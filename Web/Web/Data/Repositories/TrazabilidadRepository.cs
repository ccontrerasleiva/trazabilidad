namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrazabilidadRepository : BaseRepository<Trazabilidad>, Interfaces.ITrazabilidadRepository
    {
        public TrazabilidadRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}