namespace Services.Configuration
{
    using AutoMapper;
    using System.Linq;

    public class MappingService
    {
        public static void RegisterMappings()
        {
            try
            {
                Mapper.Initialize(config =>
                {
                    config.ForAllMaps((typeMap, map) => map.MaxDepth(0));

                    //Models
                    config.CreateMap<Domain.Models.Carro, ViewModels.Models.Carro>().ReverseMap();
                    config.CreateMap<Domain.Models.Tag, ViewModels.Models.Tag>().ReverseMap();
                    config.CreateMap<Domain.Models.Statu, ViewModels.Models.Statu>().ReverseMap();
                    config.CreateMap<Domain.Models.Contenedor, ViewModels.Models.Contenedor>().ReverseMap();
                    config.CreateMap<Domain.Models.Cliente, ViewModels.Models.Cliente>().ReverseMap();
                    config.CreateMap<Domain.Models.Ruta, ViewModels.Models.Ruta>().ReverseMap();
                    config.CreateMap<Domain.Models.Locomotora, ViewModels.Models.Locomotora>().ReverseMap();
                    config.CreateMap<Domain.Models.Conductor, ViewModels.Models.Conductor>().ReverseMap();

                    config.CreateMap<Domain.Models.Trazabilidad, ViewModels.Models.Trazabilidad>().ReverseMap();
                    config.CreateMap<Domain.Models.TrazabilidadMovLocomotora, ViewModels.Models.TrazabilidadMovLocomotora>().ReverseMap();
                    config.CreateMap<Domain.Models.TrazabilidadMovCarro, ViewModels.Models.TrazabilidadMovCarro>().ReverseMap();

                    config.CreateMap<Domain.Models.Armado, ViewModels.Models.Armado>().ReverseMap();
                    config.CreateMap<Domain.Models.MovArmado, ViewModels.Models.MovArmado>().ReverseMap();

                    config.CreateMap<Domain.Models.TrazaUbicacionContenedor, ViewModels.Models.TrazaUbicacionContenedor>().ReverseMap();
                    config.CreateMap<Domain.Models.TrazaUbicacionCarro, ViewModels.Models.TrazaUbicacionCarro>().ReverseMap();
                    config.CreateMap<Domain.Models.TrazaUbicacionLocomotora, ViewModels.Models.TrazaUbicacionLocomotora>().ReverseMap();



                    //config.CreateMap<Domain.Models.ETConvoyCabecera, ViewModels.Models.ETConvoyCabecera>().ReverseMap();

                    //config.CreateMap<Domain.Models.PesoConvoy, ViewModels.Models.PesoConvoy>().ReverseMap();

                    //config.CreateMap<Domain.Models.Estacion, ViewModels.Models.Estacion>().ReverseMap();
                    //config.CreateMap<Domain.Models.Festivo, ViewModels.Models.Festivo>().ReverseMap();
                    //config.CreateMap<Domain.Models.Jornada, ViewModels.Models.Jornada>().ReverseMap();
                    //config.CreateMap<Domain.Models.Actividad, ViewModels.Models.Actividad>().ReverseMap();

                    //config.CreateMap<Domain.Models.Servicio, ViewModels.Models.Servicio>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tarea_Patio, ViewModels.Models.Tarea_Patio>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tiempo_Hapa, ViewModels.Models.Tiempo_Hapa>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tramo, ViewModels.Models.Tramo>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tripulante_Persona, ViewModels.Models.TripulantePersona>().ReverseMap();
                    //config.CreateMap<Domain.Models.Festivo_Estacion, ViewModels.Models.Festivo_Estacion>().ReverseMap();
                    //config.CreateMap<Domain.Models.Ausencia, ViewModels.Models.Ausencia>().ReverseMap();
                    //config.CreateMap<Domain.Models.Gps, ViewModels.Models.Gps>().ReverseMap();
                    //config.CreateMap<Domain.Models.HapaTripulante, ViewModels.Models.HapaTripulante>().ReverseMap();
                    //config.CreateMap<Domain.Models.Itinerario, ViewModels.Models.Itinerario>().ReverseMap();
                    //config.CreateMap<Domain.Models.Novedad, ViewModels.Models.Novedad>().ReverseMap();
                    //config.CreateMap<Domain.Models.Pasajero, ViewModels.Models.Pasajero>().ReverseMap();
                    //config.CreateMap<Domain.Models.Patio, ViewModels.Models.Patio>().ReverseMap();
                    //config.CreateMap<Domain.Models.Programacion, ViewModels.Models.Programacion>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tren, ViewModels.Models.Tren>().ReverseMap();

                    //config.CreateMap<Domain.Models.Servicio_Cliente, ViewModels.Models.Servicio_Cliente>().ReverseMap();
                    //config.CreateMap<Domain.Models.Viatico, ViewModels.Models.Viatico>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tripulante_Persona, ViewModels.Models.TripulantePersona>().ReverseMap();
                    //config.CreateMap<Domain.Models.Ausencia, ViewModels.Models.Ausencia>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tripulante, ViewModels.Models.Tripulante>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tren_Tramo, ViewModels.Models.Tren_Tramo>()
                    //.ForMember(x => x.Tramo, opt => opt.Ignore())
                    //.ForMember(x => x.Tren, opt => opt.Ignore())
                    //.ForMember(x => x.Origen, opt => opt.Ignore())
                    //.ForMember(x => x.Destino, opt => opt.Ignore())
                    //.ReverseMap();
                    //config.CreateMap<Domain.Models.Tramo_Itinerario, ViewModels.Models._Tramo_Itinerario>().ReverseMap();
                    //config.CreateMap<Domain.Models.Tren_Locomotora, ViewModels.Models.Tren_Locomotora>().ReverseMap();

                });
            }
            catch (System.Exception)
            {

                // throw;
            }


        }
    }
}