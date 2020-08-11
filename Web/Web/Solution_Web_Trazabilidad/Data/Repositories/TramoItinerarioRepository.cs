namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TramoItinerarioRepository : BaseRepository<Tramo_Itinerario>, Interfaces.ITramoItinerarioRepository
    {
        public TramoItinerarioRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}