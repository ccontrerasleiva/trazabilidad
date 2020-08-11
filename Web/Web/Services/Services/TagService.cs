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



    public class TagService : BaseService<Tag>, ITagService
    {
        public TagService(IBaseRepository<Tag> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Tag> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.Tag>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Tag>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
               
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Tag> Save(ViewModels.Models.Tag item)
        {
            var vTag = Mapper.Map<Tag>(item);
            return await Save(vTag);
        }


        public void Edit(ViewModels.Models.Tag item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.Descripcion= item.Descripcion;
          
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.Tag item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Tag GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Tag>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
