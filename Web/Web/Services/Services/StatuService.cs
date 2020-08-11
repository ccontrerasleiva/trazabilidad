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



    public class StatuService : BaseService<Statu>, IStatuService
    {
        public StatuService(IBaseRepository<Statu> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Statu> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.Statu>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Statu>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
               
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Statu> Save(ViewModels.Models.Statu item)
        {
            var vStatu = Mapper.Map<Statu>(item);
            return await Save(vStatu);
        }


        public void Edit(ViewModels.Models.Statu item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.Descripcion= item.Descripcion;
          
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.Statu item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Statu GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Statu>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
