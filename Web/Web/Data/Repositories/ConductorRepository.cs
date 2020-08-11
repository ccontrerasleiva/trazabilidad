namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class ConductorRepository : BaseRepository<Conductor>, Interfaces.IConductorRepository
    {
        public ConductorRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}