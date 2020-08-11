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



    public class CarroService : BaseService<Carro>, ICarroService
    {
        public CarroService(IBaseRepository<Carro> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Carro> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.Carro>>
                   (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Carro>();   //agregado.
                return x;                                                         //(_repository.Get().Where(ac => ac.Deshabilitado == false)) ?? Enumerable.Empty<ViewModels.Models.Locomotora>(); //comentado porque solo mostraba los "habilitados".
            
                //List<ViewModels.Models.Carro> lst_festivo = new List<ViewModels.Models.Carro>();
                //var carroConsulta = _repository.Get(x => x.Base).Where(x => x.Id > 0);
                //foreach (var item in carroConsulta)
                //{
                //    ViewModels.Models.Carro estacion = new ViewModels.Models.Carro();

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


        public async Task<Carro> Save(ViewModels.Models.Carro item)
        {
            var vCarro = Mapper.Map<Carro>(item);
            return await Save(vCarro);
        }


        public void Edit(ViewModels.Models.Carro item)
        {
            var td = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            td.Descripcion= item.Descripcion;
            td.Patente = item.Patente;
            td.Id= item.Id;
            td.Deshabilitado = item.Deshabilitado;

            _repository.Update(td);
            _repository.SaveChangesAsync();
        }

        public void Delete(ViewModels.Models.Carro item)
        {
            var del = _repository.Get().SingleOrDefault(x => x.Id == item.Id);
            del.Deshabilitado = true;
            _repository.Update(del);
            _repository.SaveChangesAsync();
        }

        public ViewModels.Models.Carro GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Carro>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
