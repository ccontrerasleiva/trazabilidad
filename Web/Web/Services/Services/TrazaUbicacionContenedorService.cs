namespace Services
{
    using AutoMapper;
    using Data.Extensions.Interfaces;
    using Domain.Models;
    using Services.Extensions;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Threading.Tasks;



    public class TrazaUbicacionContenedorService : BaseService<TrazaUbicacionContenedor>, ITrazaUbicacionContenedorService
    {
        public TrazaUbicacionContenedorService(IBaseRepository<TrazaUbicacionContenedor> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.TrazaUbicacionContenedor> GetViewModelList()
        {
            try
            {
                ////var x = Mapper.Map<IEnumerable<ViewModels.Models.TrazaUbicacionContenedor>>
                //////    (_repository.Get()) ?? Enumerable.Empty<ViewModels.Models.TrazaUbicacionContenedor>();
                ////    (_repository.Get()) ?? Enumerable.Empty<ViewModels.Models.TrazaUbicacionContenedor>();
                //////(_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();   //agregado.


                //********************************************
               
              var db = new Data.ProyectoGestionContext();
                //var test = new ViewModels.Custom.GestionDiaria.CTren();
                using (var conection = db.Database.Connection)
                {
                    conection.Open();
                    var command = conection.CreateCommand();
                    command.CommandText = " EXEC [dbo].[SP_INFORME_ACTIVOS] ";
                    using (var reader = command.ExecuteReader())
                    {
                        var ubicacionContenedor =
                            ((IObjectContextAdapter)db)
                               .ObjectContext
                               .Translate<ViewModels.Models.TrazaUbicacionContenedor>(reader)
                               .ToList();

                        //ViewBag.Locomotoras = new SelectList(loco2, "Id", "Description");

                        reader.NextResult();

                        var contenedor =
                           ((IObjectContextAdapter)db)
                              .ObjectContext
                              .Translate<ViewModels.Models.Contenedor>(reader)
                              .ToList();

                        var ruta =
                           ((IObjectContextAdapter)db)
                              .ObjectContext
                              .Translate<ViewModels.Models.Ruta>(reader)
                              .ToList();

                        return ubicacionContenedor;

                    }

                }
               
                //********************************************


                //return x;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ViewModels.Custom.TrainActivo> ActivosforMap()
        {

 
            //var aaaa = _repository.Get(xx => xx.DescripcionUbiRuta, yy => yy.DescripcionUbiContenedor).ToList().OrderByDescending(s => s.Id).GroupBy(e => e.DescripcionUbiContenedor.Patente);
            //var aaa = aaaa.Select(x => x.FirstOrDefault());  //.Where(x => x.DescripcionUbiContenedor.Patente == 8); 
            var latestReports = new List<ViewModels.Custom.TrainActivo>();
            
            //foreach (var item in aaa)
            //{
            //        ViewModels.Custom.TrainActivo aa = new ViewModels.Custom.TrainActivo();
            //    aa.id = item.Id;
            //    aa.Patente = item.DescripcionUbiContenedor.Patente.ToString();
            //    aa.location = item.DescripcionUbiRuta.Sigla_Codelco;
            //    aa.activo = "2";
            //    aa.Longitude = item.DescripcionUbiRuta.Longitud;
            //    aa.Latitude = item.DescripcionUbiRuta.Latitud;
            //    aa.Trocha = item.DescripcionUbiRuta.Trocha;
            //    latestReports.Add(aa);
            // }
                                          
            //latestReports = latestReports.OrderBy(f=>f.location).ToList();

            var db = new Data.ProyectoGestionContext();
            //var test = new ViewModels.Custom.GestionDiaria.CTren();
            using (var conection = db.Database.Connection)
            {
                conection.Open();
                var command = conection.CreateCommand();

                command.CommandText = " EXEC [dbo].[SP_ACTIVOS_FOR_MAP] ";
                using (var reader = command.ExecuteReader())
                {
                    var uaCT =
                        ((IObjectContextAdapter)db)
                           .ObjectContext
                           .Translate<ViewModels.Custom.TrainActivo>(reader)
                           .ToList();

                    //ViewBag.Locomotoras = new SelectList(loco2, "Id", "Description");

                    //return uHistorico;
                    //return Json(uHistorico);
                    latestReports = uaCT;
                }

            }


            return latestReports ?? Enumerable.Empty<ViewModels.Custom.TrainActivo>();
        }

        public IEnumerable<ViewModels.Custom.ResumenActivo> ActivosListado()
        {

            //var aaaa = _repository.Get(xx => xx.DescripcionUbiContenedor, yy => yy.DescripcionUbiRuta).ToList().OrderByDescending(s => s.Id).GroupBy(e => e.DescripcionUbiContenedor.Patente);
            //var aaa = aaaa.Select(x => x.FirstOrDefault());
            var latestReports = new List<ViewModels.Custom.ResumenActivo>();

            //foreach (var item in aaa)
            //{
            //    ViewModels.Custom.ResumenActivo aa = new ViewModels.Custom.ResumenActivo();
            //    aa.IdContenedor = item.IdContenedor.ToString();
            //    aa.Patente = item.DescripcionUbiContenedor.Patente.ToString();
            //    aa.IdRuta = item.IdRuta.ToString();
            //    aa.Descripcion_Ruta = item.DescripcionUbiRuta.Descripcion;
            //    aa.Sigla_Codelco = item.DescripcionUbiRuta.Sigla_Codelco;
            //    aa.Fecha_Actualizacion = item.Updated.ToString();
            //    latestReports.Add(aa);
            //}

            //********************************************
            var db = new Data.ProyectoGestionContext();
            //var test = new ViewModels.Custom.GestionDiaria.CTren();
            using (var conection = db.Database.Connection)
            {
                conection.Open();
                var command = conection.CreateCommand();
                command.CommandText = " EXEC [dbo].[SP_INFORME_ACTIVOS] ";
                using (var reader = command.ExecuteReader())
                {
                    //var ubicacionContenedor =
                    //    ((IObjectContextAdapter)db)
                    //       .ObjectContext
                    //       .Translate<ViewModels.Models.TrazaUbicacionContenedor>(reader)
                    //       .ToList();
                    reader.NextResult();
                    //var contenedor =
                    //   ((IObjectContextAdapter)db)
                    //      .ObjectContext
                    //      .Translate<ViewModels.Models.Contenedor>(reader)
                    //      .ToList();
                    reader.NextResult();
                    //var ruta =
                    //   ((IObjectContextAdapter)db)
                    //      .ObjectContext
                    //      .Translate<ViewModels.Models.Ruta>(reader)
                    //      .ToList();
                    reader.NextResult();
                    var Tra =
                      ((IObjectContextAdapter)db)
                         .ObjectContext
                         .Translate<ViewModels.Custom.ResumenActivo>(reader)
                         .ToList();

                    latestReports = Tra;
                }
            }
            //********************************************

            return latestReports ?? Enumerable.Empty<ViewModels.Custom.ResumenActivo>();
        }

        public ViewModels.Models.TrazaUbicacionContenedor GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.TrazaUbicacionContenedor>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
