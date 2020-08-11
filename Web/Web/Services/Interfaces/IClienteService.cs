namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClienteService : Extensions.IBaseService<Domain.Models.Cliente>
    {
        ViewModels.Models.Cliente GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Cliente> GetViewModelList();

        Task<Domain.Models.Cliente> Save(ViewModels.Models.Cliente item);

        void Edit(ViewModels.Models.Cliente item);

        void Delete(ViewModels.Models.Cliente item);
    }
}