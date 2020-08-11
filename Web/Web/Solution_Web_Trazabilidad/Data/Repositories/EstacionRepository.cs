namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class EstacionRepository : BaseRepository<Estacion>, Interfaces.IEstacionRepository
    {
        public EstacionRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}