namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;

    public class TagRepository : BaseRepository<Tag>, Interfaces.ITagRepository
    {
        public TagRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}