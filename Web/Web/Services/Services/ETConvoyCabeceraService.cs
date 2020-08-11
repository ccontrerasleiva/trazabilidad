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



    public class ETConvoyCabeceraService : BaseService<ETConvoyCabecera>, IETConvoyCabeceraService
    {
        public ETConvoyCabeceraService(IBaseRepository<ETConvoyCabecera> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.ETConvoyCabecera> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.ETConvoyCabecera>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.ETConvoyCabecera>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
               
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<ETConvoyCabecera> Save(ViewModels.Models.ETConvoyCabecera item)
        {
            var vETConvoyCabecera = Mapper.Map<ETConvoyCabecera>(item);
            return await Save(vETConvoyCabecera);
        }


        public void Edit(ViewModels.Models.ETConvoyCabecera item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.CnvBasCod = item.CnvBasCod;
          
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.ETConvoyCabecera item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.ETConvoyCabecera GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.ETConvoyCabecera>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
