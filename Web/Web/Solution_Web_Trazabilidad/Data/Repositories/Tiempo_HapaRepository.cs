namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class Tiempo_HapaRepository : BaseRepository<Tiempo_Hapa>, Interfaces.ITiempo_HapaRepository
    {
        public Tiempo_HapaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}