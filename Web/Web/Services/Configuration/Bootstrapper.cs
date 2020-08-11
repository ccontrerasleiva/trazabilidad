namespace Services.Configuration
{
    using Services.Interfaces;
    using Ninject;
    using Ninject.Web.Common;
    using Services.Interfaces;

    public static class Bootstrapper
    {
        public static void RegisterTypes(this IKernel kernel)
        {
            #region Repository

            kernel.Bind(typeof(Data.Extensions.Interfaces.IBaseRepository<>)).To(typeof(Data.Extensions.BaseRepository<>)).InRequestScope();

            #endregion Repository

            #region Services

                  //kernel.Bind<IEstacionService>().To<EstacionService>();
            //kernel.Bind<ISchedulesService>().To<ScheduleService>();
            //kernel.Bind<IRoutesService>().To<RoutesService>();
            //kernel.Bind<ILocomotiveService>().To<LocomotiveService>();
            //kernel.Bind<ITravelTimeService>().To<TravelTimeService>();
            //kernel.Bind<IPassengerTravelTimeService>().To<PassengerTravelTimeService>();
            //kernel.Bind<ITrainService>().To<TrainService>();
            //kernel.Bind<ITrainRouteLocomotiveCrewService>().To<TrainRouteLocomotiveCrewService>();
            //kernel.Bind<INewsService>().To<NewsService>();
            //kernel.Bind<ITrainRouteService>().To<TrainRouteService>();
            //kernel.Bind<ITrainGPSLogService>().To<TrainGPSLogService>();
            //kernel.Bind<ITramo_ItinerarioService>().To<Tramo_ItinerarioService>();
            //kernel.Bind<ITrenService>().To<TrenService>();
            //kernel.Bind<IJornadaService>().To<JornadaService>();
            //kernel.Bind<ILocomotoraService>().To<LocomotoraService>();
            //kernel.Bind<IGpsService>().To<GpsService>();
            //kernel.Bind<IEstacionService>().To<EstacionService>();
            //kernel.Bind<IItinerarioService>().To<ItinerarioService>();
            //kernel.Bind<IServicioService>().To<ServicioService>();
            //kernel.Bind<INovedadService>().To<NovedadService>();
            //kernel.Bind<ITiempo_HapaService>().To<Tiempo_HapaService>();
            //kernel.Bind<ITramoService>().To<TramoService>();
            
            //kernel.Bind<IProgramacionService>().To<ProgramacionService>();
            //kernel.Bind<ITripulante_PersonaService>().To<Tripulante_PersonaService>();
            //kernel.Bind<ITripulanteService>().To<TripulanteService>();
            
            //kernel.Bind<ITren_TramoService>().To<Tren_TramoService>();
            //kernel.Bind<IActividadService>().To<ActividadService>();
            //kernel.Bind<IFestivoService>().To<FestivoService>();
            //kernel.Bind<IAusenciaService>().To<AusenciaService>();
            kernel.Bind<ICarroService>().To<CarroService>();
            kernel.Bind<ITagService>().To<TagService>();
            kernel.Bind<IStatuService>().To<StatuService>();
            kernel.Bind<IContenedorService>().To<ContenedorService>();
            kernel.Bind<IClienteService>().To<ClienteService>();
            kernel.Bind<IRutaService>().To<RutaService>();
            kernel.Bind<ILocomotoraService>().To<LocomotoraService>();
            kernel.Bind<IConductorService>().To<ConductorService>();

            kernel.Bind<ITrazabilidadService>().To<TrazabilidadService>();
            kernel.Bind<ITrazabilidadMovLocomotoraService>().To<TrazabilidadMovLocomotoraService>();
            kernel.Bind<ITrazabilidadMovCarroService>().To<TrazabilidadMovCarroService>();

            kernel.Bind<IHistoriialActivoService>().To<ArmadoService>();
            kernel.Bind<IMovArmadoService>().To<MovArmadoService>();

            kernel.Bind<ITrazaUbicacionContenedorService>().To<TrazaUbicacionContenedorService>();
            kernel.Bind<ITrazaUbicacionCarroService>().To<TrazaUbicacionCarroService>();
            kernel.Bind<ITrazaUbicacionLocomotoraService>().To<TrazaUbicacionLocomotoraService>();

            //kernel.Bind<IETConvoyCabeceraService >().To<ETConvoyCabeceraService>();

            //kernel.Bind<IPesoConvoyService>().To<PesoConvoyService>();

            #endregion Services
        }
    }
}