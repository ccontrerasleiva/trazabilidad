namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class LocomotoraRepository : BaseRepository<Locomotora>, Interfaces.ILocomotoraRepository
    {
        public LocomotoraRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}