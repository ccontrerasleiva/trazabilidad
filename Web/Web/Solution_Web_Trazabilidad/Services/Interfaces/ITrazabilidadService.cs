namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrazabilidadService : Extensions.IBaseService<Domain.Models.Trazabilidad>
    {
        ViewModels.Models.Trazabilidad GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Trazabilidad> GetViewModelList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}