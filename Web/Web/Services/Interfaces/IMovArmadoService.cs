namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMovArmadoService : Extensions.IBaseService<Domain.Models.MovArmado>
    {
        //ViewModels.Models.Armado GetByIdVM(int id);

        //IEnumerable<ViewModels.Models.Trazabilidad> GetViewModelList();

        IEnumerable<ViewModels.Models.MovArmado> GetViewModelList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}