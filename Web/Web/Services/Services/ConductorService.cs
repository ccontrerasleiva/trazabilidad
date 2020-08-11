﻿namespace Services
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



    public class ConductorService : BaseService<Conductor>, IConductorService
    {
        public ConductorService(IBaseRepository<Conductor> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Conductor> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.Conductor>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Conductor>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
              
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Conductor> Save(ViewModels.Models.Conductor item)
        {
            var vConductor = Mapper.Map<Conductor>(item);
            return await Save(vConductor);
        }


        public void Edit(ViewModels.Models.Conductor item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.Nombres= item.Nombres;
            td.Apellidos= item.Apellidos;
            td.Celular = item.Celular;
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.Conductor item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Conductor GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Conductor>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
