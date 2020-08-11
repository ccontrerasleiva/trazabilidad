namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class ContenedorRepository : BaseRepository<Contenedor>, Interfaces.IContenedorRepository
    {
        public ContenedorRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}