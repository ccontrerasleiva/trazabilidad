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



    public class PesoConvoyService : BaseService<PesoConvoy>, IPesoConvoyService
    {
        public PesoConvoyService(IBaseRepository<PesoConvoy> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.PesoConvoy> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.PesoConvoy>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.PesoConvoy>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
               
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<PesoConvoy> Save(ViewModels.Models.PesoConvoy item)
        {
            var vPesoConvoy = Mapper.Map<PesoConvoy>(item);
            return await Save(vPesoConvoy);
        }


        public void Edit(ViewModels.Models.PesoConvoy item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.Descripcion= item.Descripcion;
          
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.PesoConvoy item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.PesoConvoy GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.PesoConvoy>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
