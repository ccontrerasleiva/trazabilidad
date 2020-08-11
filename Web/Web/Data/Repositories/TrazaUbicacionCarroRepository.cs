namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrazaUbicacionCarroRepository : BaseRepository<TrazaUbicacionCarro>, Interfaces.ITrazaUbicacionCarroRepository
    {
        public TrazaUbicacionCarroRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}