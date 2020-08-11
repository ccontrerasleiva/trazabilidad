namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class MovArmadoRepository : BaseRepository<MovArmado>, Interfaces.IMovArmadoRepository
    {
        public MovArmadoRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}