namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class RutaRepository : BaseRepository<Ruta>, Interfaces.IRutaRepository
    {
        public RutaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}