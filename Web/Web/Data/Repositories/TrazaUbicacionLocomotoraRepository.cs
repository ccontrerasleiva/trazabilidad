namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrazaUbicacionLocomotoraRepository : BaseRepository<TrazaUbicacionLocomotora>, Interfaces.ITrazaUbicacionLocomotoraRepository
    {
        public TrazaUbicacionLocomotoraRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}