namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class NovedadRepository : BaseRepository<Novedad>, Interfaces.INovedadRepository
    {
        public NovedadRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}