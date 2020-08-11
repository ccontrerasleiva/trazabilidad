namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITagService : Extensions.IBaseService<Domain.Models.Tag>
    {
        ViewModels.Models.Tag GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Tag> GetViewModelList();

        Task<Domain.Models.Tag> Save(ViewModels.Models.Tag item);

        void Edit(ViewModels.Models.Tag item);

        //void Delete(ViewModels.Models.Tag item);
    }
}