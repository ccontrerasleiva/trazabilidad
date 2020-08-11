namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrazaUbicacionCarroService : Extensions.IBaseService<Domain.Models.TrazaUbicacionCarro>
    {
        ViewModels.Models.TrazaUbicacionCarro GetByIdVM(int id);
        IEnumerable<ViewModels.Custom.TrainActivo> ActivosforMap();
        IEnumerable<ViewModels.Models.TrazaUbicacionCarro> GetViewModelList();

        //IEnumerable<ViewModels.Models.IGArmado> GetViewModelArmadoList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}