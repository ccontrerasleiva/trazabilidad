namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class ClienteRepository : BaseRepository<Cliente>, Interfaces.IClienteRepository
    {
        public ClienteRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}