namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IStatuService : Extensions.IBaseService<Domain.Models.Statu>
    {
        ViewModels.Models.Statu GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Statu> GetViewModelList();

        Task<Domain.Models.Statu> Save(ViewModels.Models.Statu item);

        void Edit(ViewModels.Models.Statu item);

        //void Delete(ViewModels.Models.Statu item);
    }
}