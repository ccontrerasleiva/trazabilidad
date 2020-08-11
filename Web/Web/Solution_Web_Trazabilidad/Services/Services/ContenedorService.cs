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



    public class ContenedorService : BaseService<Contenedor>, IContenedorService
    {
        public ContenedorService(IBaseRepository<Contenedor> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Contenedor> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.Contenedor>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Contenedor>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
                //List<ViewModels.Models.Contenedor> lst_festivo = new List<ViewModels.Models.Contenedor>();
                //var ContenedorConsulta = _repository.Get(x => x.Base).Where(x => x.Id > 0);
                //foreach (var item in ContenedorConsulta)
                //{
                //    ViewModels.Models.Contenedor estacion = new ViewModels.Models.Contenedor();

            //    estacion.Id = item.Id_Base;
            //    estacion.Nombre = item.Base.Nombre;

            //    ViewModels.Models.Festivo festivo = new ViewModels.Models.Festivo();
            //    festivo.Id = item.Id;
            //    festivo.Fecha = item.Fecha;
            //    festivo.Descripcion = item.Descripcion;
            //    festivo.Id_Base = item.Id_Base;
            //    festivo.Base = estacion;
            //    festivo.Deshabilitado = item.Deshabilitado;

            //    lst_festivo.Add(festivo);
            //}
            //return lst_festivo;
        }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Contenedor> Save(ViewModels.Models.Contenedor item)
        {
            var vContenedor = Mapper.Map<Contenedor>(item);
            return await Save(vContenedor);
        }


        public void Edit(ViewModels.Models.Contenedor item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.Descripcion= item.Descripcion;
            td.PesoTara = item.PesoTara;
            td.Patente = item.Patente;
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.Contenedor item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Contenedor GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Contenedor>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
