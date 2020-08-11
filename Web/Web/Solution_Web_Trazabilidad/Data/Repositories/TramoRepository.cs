namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TramoaRepository : BaseRepository<Tramo>, Interfaces.ITramoRepository
    {
        public TramoaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}