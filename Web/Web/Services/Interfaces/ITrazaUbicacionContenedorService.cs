namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrazaUbicacionContenedorService : Extensions.IBaseService<Domain.Models.TrazaUbicacionContenedor>
    {
        ViewModels.Models.TrazaUbicacionContenedor GetByIdVM(int id);

        IEnumerable<ViewModels.Custom.TrainActivo> ActivosforMap();

        IEnumerable<ViewModels.Custom.ResumenActivo> ActivosListado();

        IEnumerable<ViewModels.Models.TrazaUbicacionContenedor> GetViewModelList();

        //IEnumerable<ViewModels.Models.IGArmado> GetViewModelArmadoList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}