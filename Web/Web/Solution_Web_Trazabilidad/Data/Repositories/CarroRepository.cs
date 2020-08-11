namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class CarroRepository : BaseRepository<Carro>, Interfaces.ICarroRepository
    {
        public CarroRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}