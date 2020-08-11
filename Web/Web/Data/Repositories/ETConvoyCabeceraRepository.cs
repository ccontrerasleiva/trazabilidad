namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class ETConvoyCabeceraRepository : BaseRepository<ETConvoyCabecera>, Interfaces.IETConvoyCabeceraRepository 
    {
        public ETConvoyCabeceraRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}