namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IConductorService : Extensions.IBaseService<Domain.Models.Conductor>
    {
        ViewModels.Models.Conductor GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Conductor> GetViewModelList();

        Task<Domain.Models.Conductor> Save(ViewModels.Models.Conductor item);

        void Edit(ViewModels.Models.Conductor item);

        void Delete(ViewModels.Models.Conductor item);
    }
}