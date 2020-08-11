namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class ArmadoRepository : BaseRepository<Armado>, Interfaces.IArmadoRepository
    {
        public ArmadoRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}