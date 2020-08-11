namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILocomotoraService : Extensions.IBaseService<Domain.Models.Locomotora>
    {
        ViewModels.Models.Locomotora GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Locomotora> GetViewModelList();

        Task<Domain.Models.Locomotora> Save(ViewModels.Models.Locomotora item);

        void Edit(ViewModels.Models.Locomotora item);

        void Delete(ViewModels.Models.Locomotora item);
    }
}