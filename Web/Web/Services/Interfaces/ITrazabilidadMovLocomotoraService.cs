namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrazabilidadMovLocomotoraService : Extensions.IBaseService<Domain.Models.TrazabilidadMovLocomotora>
    {
        ViewModels.Models.TrazabilidadMovLocomotora GetByIdVM(int id);

        IEnumerable<ViewModels.Models.TrazabilidadMovLocomotora> GetViewModelList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}