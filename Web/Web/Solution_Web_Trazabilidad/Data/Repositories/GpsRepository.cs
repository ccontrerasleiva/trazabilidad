namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class GpsRepository : BaseRepository<Gps>, Interfaces.IGpsRepository
    {
        public GpsRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}