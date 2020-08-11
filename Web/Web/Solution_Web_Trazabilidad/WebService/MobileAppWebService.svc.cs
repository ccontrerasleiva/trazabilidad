namespace WebService
{
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using ViewModels.Custom;
    using ViewModels.Models;
    using ViewModels.WCF;
    using ViewModels.Enum;

    using WebService.Configuration;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.ComponentModel;

    [AutomapServiceBehavior]
    public class MobileAppWebService : IMobileAppWebServices
    {
        private ITrainGPSLogService _GPSLogSrvc;
        private INovedadService _newsService;
        private ITrainRouteService _tRouteService;
        private ITrenService _trainService;
        private ITren_TramoService _trenTramoService;
        private ITripulante_PersonaService _tripulante_Persona;
        private ITripulanteService _tripulanteService;
        private IJornadaService _jornadaService;
        private ITren_LocomotoraService _tren_LocomotoraService;
        private IItinerarioService _itinerarioService;
        private IEstacionService _estacionService;
        private ITramoService _tramoService;
        private IActividadService _actividadService;
        private ITramo_ItinerarioService _tramo_itinerarioService;
        private IRutaService _rutaService;
        private IGpsService _gpsService;


        public MobileAppWebService(
            ITrainGPSLogService gpsSrv,
            INovedadService nSrvc,
            ITrainRouteService trSrv,
            ITrenService trainService,
            ITren_TramoService trenTramoService,
            ITripulante_PersonaService tripulante_Persona,
            ITripulanteService tripulanteService,
            IJornadaService jornadaService,
            ITren_LocomotoraService tren_LocomotoraService,
            ITramoService tramoService,
            IEstacionService estacionService,
            IItinerarioService itinerarioService,
            IRutaService rutaService,
            IGpsService gpsService,
            ITramo_ItinerarioService tramo_itinerarioService,
            IActividadService actividadService)
        {
            _GPSLogSrvc = gpsSrv;
            _newsService = nSrvc;
            _tRouteService = trSrv;
            _trainService = trainService;
            _trenTramoService = trenTramoService;
            _trainService = trainService;
            _tripulante_Persona = tripulante_Persona;
            _tripulanteService = tripulanteService;
            _jornadaService = jornadaService;
            _tren_LocomotoraService = tren_LocomotoraService;
            _tramoService = tramoService;
            _estacionService = estacionService;
            _itinerarioService = itinerarioService;
            _rutaService = rutaService;
            _tramo_itinerarioService = tramo_itinerarioService;
            _gpsService = gpsService;
            _actividadService = actividadService;
        }

        public TrainServiceDetail ServiceDetail(string number)
        {
            //TODO: Is it train number? GetTrainByNumber?
            return new TrainServiceDetail
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Routes = new List<Tren_Tramo>
                {
                    //new ViewModels.Models.Route
                    //{
                    //    Origin = orig,
                    //    Destination = dest,
                    //    DepartureTime = DateTime.Now,
                    //    ArrivalDate = DateTime.Now.AddHours(2),
                    //    Distance = 2200,
                    //    Order = 1,
                    //},
                    //new ViewModels.Models.Route
                    //{
                    //    Origin = dest,
                    //    Destination = orig,
                    //    DepartureTime = DateTime.Now.AddHours(2),
                    //    ArrivalDate = DateTime.Now.AddHours(4),
                    //    Distance = 2200,
                    //    Order = 2,
                    //}
                }
            };
        }

        public bool ReportPosition(decimal lat, decimal lng, int trainId)
        {
            try
            {
                var resultado = _gpsService.GetByLatLon(lat, lng, trainId);

                _GPSLogSrvc.MobileReport(new Gps
                {
                    Latitud = lat,
                    Longitud = lng,
                    Id_Tren = trainId,//,
                    Fecha_Envio = DateTime.Now
                });

                if (resultado == true)
                {
                    RegistrarTramo(lat, lng, trainId);
                }
                //Obtengo Si completo la ruta
                var rutaCompleta = _trainService.ReportMobile(lat, lng, trainId);
                if (rutaCompleta == true)
                {
                    //Finalizar Servicio
                    //return StopService(trainId);
                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                RegistrarLog(ex.Message.ToString() + ex.StackTrace.ToString(), "TerminarActividad", "MobileAppWebService");
                throw ex;
            }
        }

        public bool RegistrarTramo(decimal lat, decimal lng, int id_tren)
        {
            bool resultado = false;
            DateTime dt = new DateTime();
            dt = Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific();

            var tren = _trainService.GetByIdVM(id_tren);
            var idruta = _rutaService.GetByIdItinerario(tren.Id_Itinerario);
            var ltr = _tramo_itinerarioService.GetByIdRuta(idruta.Id);

            var ttramo = _trainService.GetEstacionGeoCerca(ltr, lat, lng);
            if (ttramo.Tramo != null)
            {
                if (ttramo.Tramo.Id > 0)
                {
                    var idTramo = ltr.Find(x => x.Tramo.Id_Origen == ttramo.Tramo.Id_Origen);
                    var tren_tramoOrigen = _trenTramoService.GetById_TrenTramoOrigen(new ViewModels.Models.Tren_Tramo
                    { Id_Tren = id_tren, Id_Tramo = idTramo.Id_Tramo, Id_Origen = ttramo.Tramo.Id_Origen });
                    if (tren_tramoOrigen.Id_Tramo == 0)
                    {
                        ViewModels.Models.Tren_Tramo trenTramo = new Tren_Tramo();
                        trenTramo.Id_Tren = id_tren;
                        trenTramo.Id_Tramo = ttramo.Tramo.Id;
                        trenTramo.Id_Origen = ttramo.Tramo.Id_Origen;
                        trenTramo.Id_Destino = ttramo.Tramo.Id_Destino;
                        trenTramo.Hora_Salida_Real = dt;
                        trenTramo.Hora_Llegada_Real = new DateTime(1900, 1, 1);
                        trenTramo.Created = dt;
                        trenTramo.Updated = dt;
                        _trenTramoService.Save(trenTramo);
                        resultado = true;
                    }

                    var destino = ltr.Find(x => x.Tramo.Id_Destino == ttramo.Tramo.Id_Destino);
                    var tren_tramo = _trenTramoService.GetById_TrenTramoDestino(new ViewModels.Models.Tren_Tramo
                    { Id_Tren = id_tren, Id_Tramo = destino.Id_Tramo, Id_Destino = ttramo.Tramo.Id_Destino });
                    if (tren_tramo.Id_Tramo > 0)
                    {
                        var tren_tramoOrigenx = _trenTramoService.GetById_TrenTramoOrigen(new ViewModels.Models.Tren_Tramo
                        { Id_Tren = id_tren, Id_Tramo = destino.Id_Tramo, Id_Origen = ttramo.Tramo.Id_Origen });

                        var acumulado = (int)Math.Round((dt - tren_tramoOrigenx.Hora_Salida_Real).TotalMinutes, 0, MidpointRounding.AwayFromZero);
                        tren_tramoOrigenx.Hora_Llegada_Real = dt;
                        tren_tramoOrigenx.Tiempo_Acumulado = new TimeSpan(0, acumulado, 0);
                        _trenTramoService.Update(tren_tramoOrigenx);
                        resultado = true;

                        //ViewModels.Models.Tren_Tramo trenTramoCambioO = new Tren_Tramo();
                        //trenTramoCambioO.Id_Tren = id_tren;
                        //trenTramoCambioO.Id_Tramo = ttramo.Tramo.Id;
                        //trenTramoCambioO.Id_Origen = ttramo.Tramo.Id_Origen;
                        //trenTramoCambioO.Id_Destino = ttramo.Tramo.Id_Destino;
                        //trenTramoCambioO.Hora_Salida_Real = dt;
                        //trenTramoCambioO.Hora_Llegada_Real = new DateTime(1900,1,1);
                        //trenTramoCambioO.Created = dt;
                        //trenTramoCambioO.Updated = dt;
                        //_trenTramoService.Save(trenTramoCambioO);
                        resultado = true;
                    }
                }
            }
            return resultado;
        }
        /*
        public bool RegistrarTramo(decimal lat,decimal lng,int id_tren)
        {
            try
            {
                var tren = _trainService.GetByIdVM(id_tren);
                var idruta = _rutaService.GetByIdItinerario(tren.Id_Itinerario);
                var ltr = _tramo_itinerarioService.GetByIdRuta(idruta.Id);

                //var trenTramoTren = _trenTramoService.GetTrenTramoByIdTren(new Tren_Tramo { Id_Tren = tren.Id });
                //foreach (var item in trenTramoTren)
                //{
                //    ltr.RemoveAll(x => x.Id_Tramo == item.Id_Tramo);
                //}
                var ttramo = _trainService.GetEstacionGeoCerca(ltr,lat,lng);
                //RegistrarLog("Tramo Id" , "RegistrarTramo", ttramo.Tramo.Id.ToString());
                if (ttramo.Id > 0)
                {
                    //Puede que este demas
                    var idTramo0 = ltr.Find(x => x.Tramo.Id_Origen == ttramo.Tramo.Id_Origen && x.Id_Tramo == ttramo.Tramo.Id);

                    DateTime dt = new DateTime();
                    dt = Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific();

                    var tren_tramo = _trenTramoService.GetById_TrenTramoDestino(new ViewModels.Models.Tren_Tramo
                    {
                        Id_Tren = id_tren,
                        Id_Tramo = idTramo0.Id_Tramo,
                        Id_Destino = ttramo.Tramo.Id_Origen
                    });

                    if (tren_tramo.Id_Tramo == 0)
                    {
                        var tren_tramoOrigen = _trenTramoService.GetById_TrenTramoOrigen(new ViewModels.Models.Tren_Tramo
                        {
                            Id_Tren = id_tren
                        ,
                            Id_Tramo = idTramo0.Id_Tramo
                        ,
                            Id_Origen = ttramo.Tramo.Id_Origen
                        });
                        if (tren_tramoOrigen.Id_Tramo == 0)
                        {
                            ViewModels.Models.Tren_Tramo trenTramo = new Tren_Tramo();
                            trenTramo.Id_Tren = id_tren;
                            trenTramo.Id_Tramo = ttramo.Tramo.Id;
                            trenTramo.Id_Origen = ttramo.Tramo.Id_Origen;
                            trenTramo.Id_Destino = ttramo.Tramo.Id_Destino;
                            trenTramo.Hora_Salida_Real = dt;
                            trenTramo.Hora_Llegada_Real = new DateTime(1900,1,1);
                            trenTramo.Created = dt;
                            trenTramo.Updated = dt;
                            _trenTramoService.Save(trenTramo);
                        } else
                        {
                            var idTramo = ltr.Find(x => x.Tramo.Id_Origen == ttramo.Tramo.Id_Destino && x.Id_Tramo == ttramo.Tramo.Id);
                            if (idTramo != null)
                            {
                                var acumulado = (int)Math.Round((dt - tren_tramoOrigen.Hora_Salida_Real).TotalMinutes,0,MidpointRounding.AwayFromZero);
                                tren_tramoOrigen.Hora_Llegada_Real = dt;
                                tren_tramoOrigen.Tiempo_Acumulado = new TimeSpan(0,acumulado,0);
                                _trenTramoService.Update(tren_tramoOrigen);

                                ViewModels.Models.Tren_Tramo trenTramoCambioO = new Tren_Tramo();
                                trenTramoCambioO.Id_Tren = id_tren;
                                trenTramoCambioO.Id_Tramo = idTramo.Id_Tramo;
                                trenTramoCambioO.Id_Origen = idTramo.Tramo.Id_Origen;
                                trenTramoCambioO.Id_Destino = idTramo.Tramo.Id_Destino;
                                trenTramoCambioO.Hora_Salida_Real = dt;
                                trenTramoCambioO.Hora_Llegada_Real = new DateTime(1900,1,1);
                                trenTramoCambioO.Created = dt;
                                trenTramoCambioO.Updated = dt;
                                _trenTramoService.Save(trenTramoCambioO);
                            }
                        }
                    } else
                    {

                    }
                }
                return true;
            } catch (Exception ex)
            {
                RegistrarLog("error","registrar tren tramo",ex.StackTrace.ToString());
                return false;
            }
        }
*/




        public bool StopService(int id_tren)
        {

            DateTime dt = new DateTime();
            dt = Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific();
            try
            {
                var tren = _trainService.GetByIdVM(id_tren);
                if (tren != null)
                {
                    Domain.Models.Tren tr = new Domain.Models.Tren();

                    var horaTotal = Math.Round((dt - tren.HoraInicio).TotalHours, 0, MidpointRounding.AwayFromZero);
                    tren.Estado = (int)ViewModels.Enum.EstadoTren.Finalizado;
                    tren.Llegada_Real = dt;
                    tren.HoraFin = dt;
                    //tren.HoraTotal = new TimeSpan(Convert.ToInt64(horaTotal.ToString()));

                    var itinerario = tren.Id_Itinerario;

                    tr.Estado = (int)ViewModels.Enum.EstadoTren.Finalizado;
                    tr.Llegada_Real = dt;
                    tr.HoraFin = dt;
                    tr.HoraInicio = tren.HoraInicio;
                    tr.Tipo = tren.Tipo;
                    tr.Hora_Presentacion = DateTime.Now; // Pendiente
                                                         // tr.Id_Itinerario = tren.Id_Itinerarios;

                    //tr.HoraTotal = new TimeSpan(Convert.ToInt64(horaTotal.ToString()));
                    //using (SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ViaTrenDB; Integrated Security = True;")) {

                    using (SqlConnection connection = new SqlConnection("Data Source=tcp:fepasasql01.database.windows.net,1433;Initial Catalog=ViaTrenDB;User ID=AdminFepasa@fepasasql01.database.windows.net;Password=Fepasa.2018*+;"))
                    {
                        //string queryString = "UPDATE TR_Tren SET Estado=" + tren.Estado.ToString() + ", fecha_modificacion='" + Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific().ToString("yyyy-MM-dd HH:mm:ss") + "' ,  Llegada_Real='" + Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific().ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE Id_Tren=" + id_tren;
                        string queryString = "UPDATE TR_Tren SET Estado=" + tren.Estado.ToString() + ", fecha_modificacion='" + Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific().ToString("yyyy-MM-dd HH:mm:ss") + "' ,  Llegada_Real='" + Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific().ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE Id_Tren=" + id_tren;
                        SqlCommand command = new SqlCommand(queryString, connection);
                        command.Connection.Open();
                        command.ExecuteNonQuery();

                    }
                    //var result = _trainService.Save(tr);
                    //var result = _trainService.Save(tren);

                    TerminarActividad(new ViewModels.Models.Tren_Locomotora { Id = id_tren });

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                RegistrarLog(ex.Message.ToString(), "TerminarActividad", "MobileAppWebService");
                throw ex;
            }
        }



        public IEnumerable<CrewService> GetUserFinishedTrains(string azureId)
        {
            var consulta = _tripulanteService.Get(tr => tr.Tren_Locomotora, tr => tr.Actividades);
            //Get person from her Id Azure
            var _rutPersona = _tripulante_Persona.GetByIdAzure(azureId).Rut;

            //Get locomotora
            var _locomotora = _tripulanteService.GetByRut(_rutPersona);

            //Get train 
            var test = _tripulanteService.GetByRut(_rutPersona);
            var _idTren = _tripulanteService.GetByRut(_rutPersona).Tren_Locomotora.Id;


            var _trenLocomotora = _tren_LocomotoraService.GetByIdTren(_idTren).Estado = (int)EstadoTren.ATiempo;

            var trains = _trainService.GetUserCompletedTrains(azureId, _idTren);
            return trains;
        }

        public IEnumerable<CrewService> GetUserPendingTrains(string azureId)
        {
            var trains = _trainService.GetUserPendingTrains(azureId);
            return trains;
        }

        public void ReportNews(string type, string description, int trainId)
         => _newsService.Generate(type, description, trainId);

        public bool CheckServiceAvailability(decimal lat, decimal lng, int trainId, string azureId)
        {
            var result = _trainService.CheckServiceAvailability(lat, lng, trainId, azureId);
            return result;
        }

        public bool GetUserPendingWorkDay(string azureId)
        {
            int jornadaId = _trainService.GetUserTodayTrains(azureId);
            if (jornadaId != -1) return true;
            else return false;
            //return _jornadaService.Availability(jornadaId); //No puede ser L (Libre)//Feriado//PG//Vacaciones//Reposo
        }

        #region servicios
        //public bool StopWorkDay(string azureId)
        //{
        //    var persona = _tripulante_Persona.GetByIdAzure(azureId);
        //    if (persona == null)
        //    {
        //        return false;
        //    }
        //    var result = _jornadaService.TerminarJornada(persona);
        //    if (result.Status.ToString() != "WaitingForActivation")
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public bool StartService(int trainId, string azureId, int id_actividad)
        {
            if (id_actividad == 0) throw new System.ArgumentException("Código de actividad debe no debe ser cero", "");

            //traer tripulante de acuerdo al idAzure
            var tripulante = _tripulante_Persona.GetByIdAzure(azureId);
            //var rut = _tripulanteService.Get().
            try
            {
                //Pendiente: Enviar directamente rut del tripulante
                var tranCambiado = _tRouteService.DepartTrain(trainId, azureId);
                if (tranCambiado)
                {
                    IniciarActividad(tripulante, id_actividad);
                }
                return true;
            }
            catch (Exception ex)
            {
                RegistrarLog(ex.Message.ToString(), "TerminarActividad", "MobileAppWebService");
                throw ex;
            }
        }

        public bool RegisterDeviceID(string azureId, string dispositivoID)
        {

            var tripulante = _tripulante_Persona.saveDeviceID(azureId, dispositivoID);

            return true;
        }

        public void RegisterIdAzure(string email, string azureId)
        {
            var tripulante = _tripulante_Persona.saveIdAzure(email, azureId);
        }

        public int startWorkDay(string azureId)
        {
            try
            {
                var tripulante = _tripulante_Persona.GetByIdAzure(azureId);
                return _jornadaService.IniciarJornada(tripulante.Id);
            }
            catch (Exception ex)
            {
                // RegistrarLog(ex.Message.ToString(),"IniciarJornada","MobileAppWebService");
                return -1;
                throw ex;

            }
            return 0;
        }

        public async void stopWorkDay(int Id_Jornada)
        {
            try
            {
                await _jornadaService.TerminarJornada(new ViewModels.Models.Jornada { Id = Id_Jornada });
            }
            catch (Exception ex)
            {
                //RegistrarLog(ex.Message.ToString(),"TerminadaJornada","MobileAppWebService");
                throw ex;
            }
        }

        #endregion

        #region metodosTripulante_Persona 
        private void IniciarActividad(ViewModels.Models.TripulantePersona tripulante, int id_actividad)
        {
            try
            {
                //IniciarJornada va en WS propio
                /*  var actividades = _actividadService.GetJornadasByIdActividad(id_actividad);

                  if (actividades.Count > 0)
                  {
                      var jornada = _jornadaService.GetJornadasIniciadasListById(new ViewModels.Models.Jornada { Id = actividades[0].Id_Jornada });
                      if (jornada.Count == 0)
                      {

                          _jornadaService.IniciarJornada(actividades[0].Id_Jornada); //Iniciar Jornada
                      }
                  }*/

                _actividadService.IniciarActividad(new Actividad { Id = id_actividad }); //Iniciar Actividad
            }
            catch (Exception ex)
            {
                RegistrarLog(ex.Message.ToString(), "TerminarActividad", "MobileAppWebService");
                throw ex;
            }
        }


        private async void TerminarActividad(ViewModels.Models.Tren_Locomotora tren_Locomotora)
        {
            try
            {
                var id_tren_locomotora = _tren_LocomotoraService.GetByIdTren(tren_Locomotora.Id).Id;
                var actividades = _tripulanteService.GetByIdTrenLocomotora(id_tren_locomotora).Actividades;
                foreach (var itemA in actividades)
                {
                    await _actividadService.TerminarActividad(itemA);

                    //Termino Jornada va en método propio
                    /*List<ViewModels.Models.Actividad> lstActividad = _actividadService.GetJornadasByIdActividad(itemA.Id);
                    if (lstActividad.Count == 0)
                    {
                        await _jornadaService.TerminarJornada(new ViewModels.Models.Jornada { Id = itemA.Id_Jornada });
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                RegistrarLog(ex.Message.ToString(), "TerminarActividad", "MobileAppWebService");
                throw ex;
            }
        }


        #endregion

        #region nousados

        //Pendiente: Desactualizar
        //public bool StartWorkDay(string azureId, DateTime horaInicio, DateTime horaFin, int idTren)
        ////Sorry Julio no supe hacerlo de otra manera, favor arreglar las horas
        //{
        //    try
        //    {
        //        var persona = _tripulante_Persona.GetByIdAzure(azureId);
        //        if (persona == null)
        //        {
        //            return false;
        //        }
        //        //var _rutPersona = _tripulante_Persona.GetByIdAzure(azureId).Rut;
        //        var jornadaResult = _jornadaService.IniciarJornada(persona);

        //        if (jornadaResult.Status.ToString() == "Faulted")
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            //MIO
        //            var _rutTripulante = _tripulante_Persona.GetByIdAzure(azureId).Rut;

        //            var actividadResult = _actividadService.IniciarActividad(horaInicio, horaFin, jornadaResult.Result.Id, _rutTripulante, idTren);

        //            return true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        #endregion nousados

        #region borrardespues
        private void RegistrarLog(string Descripcion
           , string Metodo
           , string Clase
          )
        {
            string cnn = @"data source= (localdb)\mssqllocaldb;initial catalog=ViaTrenDB;integrated security= true;";
            //string cnn = "Data Source=tcp:fepasasql01.database.windows.net,1433;Initial Catalog=ViaTrenDB;User ID=AdminFepasa@fepasasql01.database.windows.net;Password=Fepasa.2018*+;";

            string fecha_creacion = Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific().ToString();
            string fecha_modificacion = Resources.Util.ZonaHoraria.GetHoraZonaHorariaPacific().ToString();

            string queryString = String.Format("INSERT INTO [dbo].[Log] ([Descripcion] ,[Metodo] ,[Clase] ,[fecha_creacion] ,[fecha_modificacion]) VALUES ('{0}','{1}','{2}','{3}','{4}')"
                                               , Descripcion, Metodo, Clase, fecha_creacion, fecha_modificacion);

            /*
            using (SqlConnection connection = new SqlConnection(cnn))
            {
                SqlCommand command = new SqlCommand(queryString,connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }*/
        }




        #endregion


    }
}

