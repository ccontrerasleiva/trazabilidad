namespace Services
{
    using AutoMapper;
    using Data.Extensions.Interfaces;
    using Domain.Models;
    using Services.Extensions;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;



    public class ArmadoService : BaseService<Armado>, IHistoriialActivoService
    {
        public ArmadoService(IBaseRepository<Armado> baseRepo) : base(baseRepo)
        {
        }
        public IEnumerable<ViewModels.Custom.TrainActivo> ActivosUpdateforMap()
        {

            var aaaa = _repository.Get(Y => Y.ArmadoMovimiento).ToList();


            var latestReports = new List<ViewModels.Custom.TrainActivo>();
            //ViewModels.Custom.TrainActivo aa;
            foreach (var item in aaaa)
            {
                foreach (var ite_d in item.ArmadoMovimiento)
                {

                    ViewModels.Custom.TrainActivo aa = new ViewModels.Custom.TrainActivo();
                    aa.id = ite_d.Id;
                    aa.Patente = ite_d.serialNumber;
                    aa.location = ite_d.locationId;
                    aa.activo = ite_d.filterValue;
                    latestReports.Add(aa);
                }
                
            }
            //Pendiente: validar uso de id por codigo

            return latestReports ?? Enumerable.Empty<ViewModels.Custom.TrainActivo>();
        }

        //public IEnumerable<ViewModels.Models.Trazabilidad> GetViewModelList()
        //{
        //    try
        //    {
        //        var x = Mapper.Map<IEnumerable<ViewModels.Models.Trazabilidad>>
        //            (_repository.Get(xx => xx.TrazaMoviLoco_Traza, yy => yy.TrazaMoviLoco_Carro)) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();
        //        //(_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();   //agregado.
        //        return x;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public IEnumerable<ViewModels.Custom.TrainActivo> ActivosforMap()
        {

            var aaaa = _repository.Get(Y => Y.ArmadoMovimiento).ToList();

            var latestReports = new List<ViewModels.Custom.TrainActivo>();
            //ViewModels.Custom.TrainActivo aa;
            foreach (var item in aaaa)
            {
                foreach (var ite_d in item.ArmadoMovimiento)
                {

                    ViewModels.Custom.TrainActivo aa = new ViewModels.Custom.TrainActivo();
                    aa.id = ite_d.Id;
                    aa.Patente = ite_d.serialNumber;
                    aa.location = ite_d.locationId;
                    aa.activo = ite_d.filterValue;
                    latestReports.Add(aa);
                }

            }
            //Pendiente: validar uso de id por codigo

            return latestReports ?? Enumerable.Empty<ViewModels.Custom.TrainActivo>();
        }


    

        public IEnumerable<ViewModels.Models.Armado> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.Armado>>
                     (_repository.Get(xx => xx.ArmadoMovimiento)) ?? Enumerable.Empty<ViewModels.Models.Armado>();
                

                //(_repository.Get(xx => xx.ArmadoMovimiento)) ?? Enumerable.Empty<ViewModels.Models.Armado>();





                //(_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.IGArmado>();   //agregado.

                //var x = Mapper.Map<IEnumerable<ViewModels.Models.Trazabilidad>>
                //  (_repository.Get(xx => xx.TrazaMoviLoco_Traza, yy => yy.TrazaMoviLoco_Carro)) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();


                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ViewModels.Custom.Portico> GetViewPorticosList()
        {
            try
            {
                var latestReports = new List<ViewModels.Custom.Portico>();

                //********************************************
                var db = new Data.ProyectoGestionContext();
                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    
                    command.CommandText = " EXEC [dbo].[SP_RUTA] ";
                    using (var reader = command.ExecuteReader())
                    {
                        var Tra =
                          ((IObjectContextAdapter)db)
                             .ObjectContext
                             .Translate<ViewModels.Custom.Portico>(reader)
                             .ToList();

                        latestReports = Tra;
                    }
                }
                //********************************************
                return latestReports ?? Enumerable.Empty<ViewModels.Custom.Portico>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*public IEnumerable<ViewModels.Custom.Cantidad_Activo> GetViewCantidadActivosList()
        {
            try
            {
                var latestReports = new List<ViewModels.Custom.Cantidad_Activo>();

                //********************************************
                var db = new Data.ProyectoGestionContext();
                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    command.CommandText = " EXEC [dbo].[SP_RUTA] ";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.NextResult();
                        var Tra =
                          ((IObjectContextAdapter)db)
                             .ObjectContext
                             .Translate<ViewModels.Custom.Cantidad_Activo>(reader)
                             .ToList();

                        latestReports = Tra;
                    }
                    conection.Close();
                }
                
                //********************************************
                return latestReports ?? Enumerable.Empty<ViewModels.Custom.Cantidad_Activo>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        */
        public DataSet GetViewCantidadActivosList()
        {
            try
            {
                //var latestReports = new List<ViewModels.Custom.Cantidad_Activo>();

                //********************************************
                var db = new Data.ProyectoGestionContext();
                var ds = new DataSet();
                DataTable dtResumen = ds.Tables.Add("ListadoActivos");
                DataTable dtOperacion = ds.Tables.Add("ResumenOperacion");
                DataTable dtOperacionTotal = ds.Tables.Add("ResumenOperacionTotal");
                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    command.CommandText = " EXEC [dbo].[RetornaListadoActivos] ";
                    using (var reader = command.ExecuteReader())
                    {
                        dtResumen.Load(reader);
                    }
                    command.CommandText = "[dbo].[RetornaListadoActivosDiariosUbicacion] '" + DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd") + "'";
                    using (var reader = command.ExecuteReader())
                    {
                        dtOperacion.Load(reader);
                    }
                    command.CommandText = "[dbo].[RetornaListadoActivosDiariosUbicacion]";
                    using (var reader = command.ExecuteReader())
                    {
                        dtOperacionTotal.Load(reader);
                    }
                    conection.Close();
                }

                //********************************************
                return ds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLocomotorasDia() {
            try
            {
 
                var db = new Data.ProyectoGestionContext();

                var dt = new DataTable();
                
                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    
                    command.CommandText = " EXEC [dbo].[Show_Loco_hoy] ";
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    conection.Close();
                }
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetContenedoresArmado(string locomotora) {
            try
            {

                var db = new Data.ProyectoGestionContext();

                var dt = new DataTable();

                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    command.CommandText = string.Format(" EXEC [dbo].[contenedores_por_armado] {0}", locomotora);
                    using (var reader = command.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    conection.Close();
                }
                return dt;

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

        public ViewModels.Models.Armado GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.Armado>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
