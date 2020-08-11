
namespace Services
{
    using AutoMapper;
    using Data.Extensions.Interfaces;
    using Domain.Models;
    using Services.Extensions;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RutaService : BaseService<Ruta>, IRutaService
    {
        public RutaService(IBaseRepository<Ruta> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Ruta> GetViewModelList()
        {
            try
            {
                return Mapper.Map<IEnumerable<ViewModels.Models.Ruta>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Ruta>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ruta> Save(ViewModels.Models.Ruta item)
        {
            var vRuta = Mapper.Map<Ruta>(item);
            return await Save(vRuta);
        }

        public void Edit(ViewModels.Models.Ruta item)
        {
            var tt = _repository.Get().SingleOrDefault(x => x.Id == item.Id);

            tt.Id = item.Id;

            tt.Descripcion = item.Descripcion;

            tt.FechaHoraInicio = item.FechaHoraInicio;

            tt.FechaHoraTermino = item.FechaHoraTermino;

            _repository.Update(tt);
            _repository.SaveChangesAsync();

        }

        public void Delete(ViewModels.Models.Ruta item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Ruta GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Ruta>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

        //public ViewModels.Models.Ruta GetByIdItinerario(int id)
        //{
        //    var x = Mapper.Map<ViewModels.Models.Ruta>
        //     (_repository.Get(ti => ti.Tramo_Itinerarios).FirstOrDefault(y => y.Id_Itinerario == id));
        //    return x;
        //}


    }
}
