namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class JornadaRepository : BaseRepository<Jornada>, Interfaces.IJornadaRepository
    {
        public JornadaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}