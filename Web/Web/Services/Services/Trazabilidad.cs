namespace Services
{
    using AutoMapper;
    using Data.Extensions.Interfaces;
    using Domain.Models;
    using Services.Extensions;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Configuration;

    public class TrazabilidadService : BaseService<Trazabilidad>, ITrazabilidadService
    {
        public TrazabilidadService(IBaseRepository<Trazabilidad> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.Trazabilidad> GetViewModelList()
        {
            try
            {
                //var x = Mapper.Map<IEnumerable<ViewModels.Models.Trazabilidad>>
                //    (_repository.Get(xx => xx.TrazaMoviLoco_Traza, yy => yy.TrazaMoviLoco_Carro)) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();

                //var db = new Data.ProyectoGestionContext();
                //var test = new ViewModels.Custom.GestionDiaria.CTren();
                    
                //using (var conection = db.Database.Connection)
                using (var conection = new  BloggingContext())
                {

                    conection.Database.Connection.Open();
                    
                    conection.Database.Initialize(force: false);
                    var command = conection.Database.Connection.CreateCommand();
                    //command.Connection = "(localdb)MSSQLLocalDB;Initial Catalog=Trazabilidad;Integrated Security= True;MultipleActiveResultSets=true;";
                        command.CommandText = " EXEC [dbo].[SP_INFORME_PESAJE] ";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.NextResult();
                        var Tra =
                                             ((IObjectContextAdapter)conection)
                                                .ObjectContext
                                                .Translate<ViewModels.Models.Trazabilidad>(reader, "Trazabilidads", MergeOption.AppendOnly)
                                                .ToList();
                        reader.NextResult();

                        var Tra_L = ((IObjectContextAdapter)conection)
                                                .ObjectContext
                                                .Translate<ViewModels.Models.TrazabilidadMovLocomotora>(reader, "TrazabilidadMovLocomotoras", MergeOption.AppendOnly)
                                                .ToList();
                        reader.NextResult();

                        var Tra_C = ((IObjectContextAdapter)conection)
                        .ObjectContext
                        .Translate<ViewModels.Models.TrazabilidadMovCarro>(reader, "TrazabilidadMovCarros", MergeOption.AppendOnly)
                        .ToList();

                        reader.NextResult();

                        var ruta = ((IObjectContextAdapter)conection)
                        .ObjectContext
                        .Translate<ViewModels.Models.Ruta>(reader, "Rutas", MergeOption.AppendOnly)
                        .ToList();

                        return Tra;
                    }
                }


                //return x;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public IEnumerable<ViewModels.Models.IGArmado> GetViewModelArmadoList()
        //{
        //    try
        //    {
        //        var x = Mapper.Map<IEnumerable<ViewModels.Models.IGArmado>>
        //            (_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.IGArmado>();   //agregado.

        //        return x;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


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

        public ViewModels.Models.Trazabilidad GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Trazabilidad>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
