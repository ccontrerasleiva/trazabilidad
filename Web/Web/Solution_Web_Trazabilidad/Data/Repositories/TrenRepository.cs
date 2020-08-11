namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TrenRepository : BaseRepository<Tren>, Interfaces.ITrenRepository
    {
        public TrenRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}