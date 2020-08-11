namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArmadoService : Extensions.IBaseService<Domain.Models.Armado>
    {
        //ViewModels.Models.Armado GetByIdVM(int id);

        //IEnumerable<ViewModels.Models.Trazabilidad> GetViewModelList();
        IEnumerable<ViewModels.Custom.TrainActivo> ActivosUpdateforMap();

        IEnumerable<ViewModels.Models.Armado> GetViewModelList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}