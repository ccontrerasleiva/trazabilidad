namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrazaUbicacionContenedorRepository : BaseRepository<TrazaUbicacionContenedor>, Interfaces.ITrazaUbicacionContenedorRepository
    {
        public TrazaUbicacionContenedorRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}