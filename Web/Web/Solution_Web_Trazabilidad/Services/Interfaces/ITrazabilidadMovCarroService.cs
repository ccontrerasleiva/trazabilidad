namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrazabilidadMovCarroService : Extensions.IBaseService<Domain.Models.TrazabilidadMovCarro>
    {
        ViewModels.Models.TrazabilidadMovCarro GetByIdVM(int id);

        IEnumerable<ViewModels.Models.TrazabilidadMovCarro> GetViewModelList();

        //Task<Domain.Models.Trazabilidad> Save(ViewModels.Models.Trazabilidad item);

        //void Edit(ViewModels.Models.Trazabilidad item);

        //void Delete(ViewModels.Models.Trazabilidad item);
    }
}