namespace Data.Repositories
{
    using Data.Extensions;
    using Domain.Models;
    //
    public class AbsenceRepository : BaseRepository<Absence>, Interfaces.IAbsenceRepository
    {
        public AbsenceRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}