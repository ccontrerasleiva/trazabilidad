namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPesoConvoyService : Extensions.IBaseService<Domain.Models.PesoConvoy>
    {
        ViewModels.Models.PesoConvoy GetByIdVM(int id);

        IEnumerable<ViewModels.Models.PesoConvoy> GetViewModelList();

        Task<Domain.Models.PesoConvoy> Save(ViewModels.Models.PesoConvoy item);

        void Edit(ViewModels.Models.PesoConvoy item);

        //void Delete(ViewModels.Models.Tag item);
    }
}