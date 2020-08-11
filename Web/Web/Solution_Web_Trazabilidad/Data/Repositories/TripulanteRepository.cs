namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TripulanteRepository : BaseRepository<Tripulante>, Interfaces.ITripulanteRepository
    {
        public TripulanteRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}