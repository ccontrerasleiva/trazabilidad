namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrazabilidadMovLocomotoraRepository : BaseRepository<TrazabilidadMovLocomotora>, Interfaces.ITrazabilidadMovLocomotoraRepository
    {
        public TrazabilidadMovLocomotoraRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}