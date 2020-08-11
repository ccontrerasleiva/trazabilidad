using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using ViewModels.Models;

namespace Services.Interfaces
{
    public interface IRutaService
    {

        ViewModels.Models.Ruta GetByIdVM(int id);

        IEnumerable<ViewModels.Models.Ruta> GetViewModelList();

        Task<Domain.Models.Ruta> Save(ViewModels.Models.Ruta item);

        void Delete(ViewModels.Models.Ruta item);

        void Edit(ViewModels.Models.Ruta item);
      
       
       
        //void Save(object p);
        //ViewModels.Models.Ruta GetByIdItinerario(int id);
    }
}