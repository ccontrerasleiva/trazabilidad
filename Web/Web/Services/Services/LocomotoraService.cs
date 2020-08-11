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

    public class LocomotoraService : BaseService<Locomotora>, ILocomotoraService
    {
        public LocomotoraService(IBaseRepository<Locomotora> baseRepo) : base(baseRepo)
        {
        }

        //TODO: generate custom view model for list display
        public IEnumerable<ViewModels.Models.Locomotora> GetViewModelList()
        {
            try
            {
                return Mapper.Map<IEnumerable<ViewModels.Models.Locomotora>>
                    (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Locomotora>();   //agregado.
                                                                                                              //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            }
            catch (Exception ex)
            {
                return null; //agregado.
                //throw ex;  //comentado.
            }
        }

        public async Task<Locomotora> Save(ViewModels.Models.Locomotora item)
        {
            var vLocomotora = Mapper.Map<Locomotora>(item);
            return await Save(vLocomotora);
        }

        public void Edit(ViewModels.Models.Locomotora item)
        {
            var tt = _repository.Get().SingleOrDefault(x => x.Id == item.Id);

            tt.Id = item.Id;

            tt.Deshabilitado = item.Deshabilitado;

            //tt.Tipo = item.Tipo;

            tt.Descripcion = item.Descripcion;

            tt.Patente = item.Patente;

            tt.PesoTara = item.PesoTara;

            //tt.Fecha_Creacion = item.Fecha_Creacion;

            //tt.Fecha_Modificacion = item.Fecha_Modificacion;

            _repository.Update(tt);
            _repository.SaveChangesAsync();

        }

        public void Delete(ViewModels.Models.Locomotora item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Locomotora GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Locomotora>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
