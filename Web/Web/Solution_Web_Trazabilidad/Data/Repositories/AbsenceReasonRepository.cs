namespace Data.Repositories
{
    //
    using Data.Extensions;
    using Domain.Models;

    public class AbsenceReasonRepository : BaseRepository<AbsenceReason>, Interfaces.IAbsenceReasonRepository
    {
        public AbsenceReasonRepository(ProyectoGestionContext context) : base(context)
        {
        }
    }
}