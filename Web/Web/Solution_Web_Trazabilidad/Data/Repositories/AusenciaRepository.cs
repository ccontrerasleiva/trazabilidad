namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class AusenciaRepository : BaseRepository<Ausencia>, Interfaces.IAusenciaRepository
    {
        public AusenciaRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}