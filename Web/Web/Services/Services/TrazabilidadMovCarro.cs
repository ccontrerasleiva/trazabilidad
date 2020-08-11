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



    public class TrazabilidadMovCarroService : BaseService<TrazabilidadMovCarro>, ITrazabilidadMovCarroService
    {
        public TrazabilidadMovCarroService(IBaseRepository<TrazabilidadMovCarro> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.TrazabilidadMovCarro> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.TrazabilidadMovCarro>>
                    (_repository.Get(/*).Where(ac => ac.Deshabilitado == false*/)) ?? Enumerable.Empty<ViewModels.Models.TrazabilidadMovCarro>(); 
                    //(_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();   //agregado.
                return x;                                                         
                
            
               
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public async Task<Trazabilidad> Save(ViewModels.Models.Trazabilidad item)
        //{
        //    var vTrazabilidad = Mapper.Map<Trazabilidad>(item);
        //    return await Save(vTrazabilidad);
        //}


        //public void Edit(ViewModels.Models.Trazabilidad item)
        //{
        //    var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
        //    td.Descripcion= item.Descripcion;
          
        //    td.Id= item.Id;
        //    td.Deshabilitado = item.Deshabilitado;

        //    _repository.Update(td);
        //    _repository.SaveChangesAsync();
        //}

        //public void Delete(ViewModels.Models.Trazabilidad item)
        //{
        //    var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
        //    del.Deshabilitado = true;
        //    _repository.Update(del);
        //    _repository.SaveChangesAsync();
        //}

        public ViewModels.Models.TrazabilidadMovCarro GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.TrazabilidadMovCarro>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
