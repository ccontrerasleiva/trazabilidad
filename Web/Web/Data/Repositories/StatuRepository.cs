namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class StatuRepository : BaseRepository<Statu>, Interfaces.IStatuRepository
    {
        public StatuRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}