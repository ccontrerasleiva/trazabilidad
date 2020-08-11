namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrazabilidadMovCarroRepository : BaseRepository<TrazabilidadMovCarro>, Interfaces.ITrazabilidadMovCarroRepository
    {
        public TrazabilidadMovCarroRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}