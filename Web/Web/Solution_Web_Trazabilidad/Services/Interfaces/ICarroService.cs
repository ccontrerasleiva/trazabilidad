namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarroService : Extensions.IBaseService<Domain.Models.Carro>
    {
        ViewModels.Models.Carro GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Carro> GetViewModelList();

        Task<Domain.Models.Carro> Save(ViewModels.Models.Carro item);

        void Edit(ViewModels.Models.Carro item);

        void Delete(ViewModels.Models.Carro item);
    }
}