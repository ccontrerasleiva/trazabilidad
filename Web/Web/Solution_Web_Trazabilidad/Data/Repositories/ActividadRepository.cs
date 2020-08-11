namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class ActividadRepository : BaseRepository<Actividad>, Interfaces.IActividadRepository
    {
        public ActividadRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}