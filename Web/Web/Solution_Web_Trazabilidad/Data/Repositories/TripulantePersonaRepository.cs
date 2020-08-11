namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TripulantePersonaRepository : BaseRepository<Tripulante_Persona>, Interfaces.ITripulantePersonaRepository
    {
        public TripulantePersonaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}