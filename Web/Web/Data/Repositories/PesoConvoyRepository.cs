namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class PesoConvoyRepository : BaseRepository<PesoConvoy>, Interfaces.IPesoConvoyRepository
    {
        public PesoConvoyRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}