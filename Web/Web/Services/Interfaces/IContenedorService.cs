namespace Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IContenedorService : Extensions.IBaseService<Domain.Models.Contenedor>
    {
        ViewModels.Models.Contenedor GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Contenedor> GetViewModelList();

        Task<Domain.Models.Contenedor> Save(ViewModels.Models.Contenedor item);

        void Edit(ViewModels.Models.Contenedor item);

        void Delete(ViewModels.Models.Contenedor item);
    }
}