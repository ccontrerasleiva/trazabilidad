namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IETConvoyCabeceraService : Extensions.IBaseService<Domain.Models.ETConvoyCabecera>
    {
        ViewModels.Models.ETConvoyCabecera GetByIdVM(int id);

        IEnumerable<ViewModels.Models.ETConvoyCabecera> GetViewModelList();

        Task<Domain.Models.ETConvoyCabecera> Save(ViewModels.Models.ETConvoyCabecera item);

        void Edit(ViewModels.Models.ETConvoyCabecera item);

        //void Delete(ViewModels.Models.Tag item);
    }
}