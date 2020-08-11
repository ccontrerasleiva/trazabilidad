namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrenLocomotoraRepository : BaseRepository<Tren_Locomotora>, Interfaces.ITrenLocomotoraRepository
    {
        public TrenLocomotoraRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}