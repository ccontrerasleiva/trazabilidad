namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TripulanteParejaRepository : BaseRepository<Tripulante_Pareja>, Interfaces.ITripulanteParejaRepository
    {
        public TripulanteParejaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}
