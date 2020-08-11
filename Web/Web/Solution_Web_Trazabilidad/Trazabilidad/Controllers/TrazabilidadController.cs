namespace Trazabilidad.Controllers
{
    using Trazabilidad.Helpers;
    using Resources.Exceptions;
    using Resources.Strings;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ViewModels.Enum;
    using ViewModels.Models;
    using ViewModels.Custom;
    using Newtonsoft.Json;
    using System.Timers;

    [Authorize]

    public class TrazabilidadController : Controller
    {
        private ITrazabilidadService _TrazabilidadService;
        private IRutaService _RutaService;
        private IClienteService _ClienteService;
        private IConductorService _ConductorService;
        private ILocomotoraService _LocomotoraService;
        private ICarroService _CarroService;
        private IContenedorService _ContenedorService;
        private IStatuService _StatuService;
        private ITagService _TagService;



        //private IJornadaService _JornadaService;
        //private ITripulante_PersonaService _TripulantePersonaService;
        //private IEstacionService _EstacionService;
        //private ITrenService _TrenService;
        //private IActividadService _ActividadService;
        //private ITren_LocomotoraService _ITren_LocomotoraService;

        #region Constructor

        public TrazabilidadController(ITrazabilidadService TrazabilidadSrvc,
                                        IRutaService RutaSrvc,
                                        IClienteService ClienteSrvc,
                                        IConductorService ConductorSrvc,
                                        ILocomotoraService LocomotoraSrvc,
                                        ICarroService CarroSrvc,
                                        IContenedorService ContenedorSrvc,
                                        IStatuService StatuSrvc,
                                        ITagService TagSrvc)
        {
            _TrazabilidadService = TrazabilidadSrvc;
            _RutaService = RutaSrvc;
            _ClienteService = ClienteSrvc;
            _ConductorService = ConductorSrvc;
            _LocomotoraService = LocomotoraSrvc;
            _CarroService = CarroSrvc;
            _ContenedorService = ContenedorSrvc;
            _StatuService = StatuSrvc;
            _TagService = TagSrvc;
        }

        #endregion Constructor



        public ActionResult ListResumenTrazabilidad()
        {
            //ViewBag.estaciones = this.GetStations();
            return View(_TrazabilidadService.GetViewModelList());
        }

        public ActionResult ListResumenTrazabilidadGrafica()
        {
            return View(_TrazabilidadService.GetViewModelList());
        }


        [HttpGet]
        public JsonResult ResumenGeneral()
        {
            List<ResumenTrazabilidad> lstResumenTrazabilidad = new List<ResumenTrazabilidad>();
            int totLocomotora=0;
            int totCarro = 0;
            int contLocomotora = 0;
            int contCarro = 0;
            string strDescripcionLocomotora = "";string strPatenteLocomotora = "";

            var _Trazabilidad = _TrazabilidadService.GetViewModelList();
         
            Boolean Ver = false;
            foreach (var item in _Trazabilidad)
            {
                Ver = true;
                ResumenTrazabilidad ResTrazabilidad = new ResumenTrazabilidad();

                var objRuta = _RutaService.GetByIdVM(item.IdRuta);
                var objCliente = _ClienteService.GetByIdVM(item.IdCliente);
                var objConductor = _ConductorService.GetByIdVM(item.IdConductor);

                ResTrazabilidad.Ruta = objRuta.Descripcion;
                ResTrazabilidad.Cliente = objCliente.Nombre;
                ResTrazabilidad.Celular_Cliente = objCliente.Celular.ToString();
                ResTrazabilidad.FechaRegistro = item.FechaRegistro.ToLongDateString();
                ResTrazabilidad.FechaInicio = item.FechaInico.ToLongDateString();
                ResTrazabilidad.FechaCierre = item.FechaCierre.ToLongDateString();
                ResTrazabilidad.Rut_Conductor = objConductor.Rut;
                ResTrazabilidad.Conductor = objConductor.Nombres + " " + objConductor.Apellidos;
                ResTrazabilidad.Celular_Conductor = objConductor.Celular;
                ResTrazabilidad.Observacion = item.Observacion;
                ResTrazabilidad.Locomotora = "";
                ResTrazabilidad.Locomotora_Patente = "";
                totLocomotora = item.TrazaMoviLoco_Traza.Count;
                totCarro = item.TrazaMoviLoco_Carro.Count;

                //if (totLocomotora <= totCarro && totLocomotora!=0)
                if ( totLocomotora != 0)
                {
                    contLocomotora = 0;contCarro = 0;
                    foreach (var cc in item.TrazaMoviLoco_Traza)
                    {
                        ResumenTrazabilidad ResTrazabilidadL = new ResumenTrazabilidad();
                        ResTrazabilidadL.Ruta = objRuta.Descripcion;
                        ResTrazabilidadL.Cliente = objCliente.Nombre;
                        ResTrazabilidadL.Celular_Cliente = objCliente.Celular.ToString();
                        ResTrazabilidadL.FechaRegistro = item.FechaRegistro.ToLongDateString();
                        ResTrazabilidadL.FechaInicio = item.FechaInico.ToLongDateString();
                        ResTrazabilidadL.FechaCierre = item.FechaCierre.ToLongDateString();
                        ResTrazabilidadL.Rut_Conductor = objConductor.Rut;
                        ResTrazabilidadL.Conductor = objConductor.Nombres + " " + objConductor.Apellidos;
                        ResTrazabilidadL.Celular_Conductor = objConductor.Celular;
                        ResTrazabilidadL.Observacion = item.Observacion;
                        ResTrazabilidadL.Locomotora = "";
                        ResTrazabilidadL.Locomotora_Patente = "";

                        var objLocomotora = _LocomotoraService.GetByIdVM(cc.IdLocomotora);
                        ResTrazabilidadL.Locomotora = objLocomotora.Descripcion;
                        ResTrazabilidadL.Locomotora_Patente = objLocomotora.Patente;
                        strDescripcionLocomotora = objLocomotora.Descripcion;
                        strPatenteLocomotora = objLocomotora.Patente;
                        contLocomotora++;
                        if (contLocomotora <= totCarro && totCarro != 0)
                        {
                            #region Carros
                            contCarro++;
                            List<TrazabilidadMovCarro> car = new List<TrazabilidadMovCarro>(item.TrazaMoviLoco_Carro);
                            ResumenTrazabilidad ResTrazabilidadC = new ResumenTrazabilidad();
                            ResTrazabilidadC.Ruta = objRuta.Descripcion;
                            ResTrazabilidadC.Cliente = objCliente.Nombre;
                            ResTrazabilidadC.Celular_Cliente = objCliente.Celular.ToString();
                            ResTrazabilidadC.FechaRegistro = item.FechaRegistro.ToLongDateString();
                            ResTrazabilidadC.FechaInicio = item.FechaInico.ToLongDateString();
                            ResTrazabilidadC.FechaCierre = item.FechaCierre.ToLongDateString();
                            ResTrazabilidadC.Rut_Conductor = objConductor.Rut;
                            ResTrazabilidadC.Conductor = objConductor.Nombres + " " + objConductor.Apellidos;
                            ResTrazabilidadC.Celular_Conductor = objConductor.Celular;
                            ResTrazabilidadC.Observacion = item.Observacion;
                            ResTrazabilidadC.Locomotora = objLocomotora.Descripcion;
                            ResTrazabilidadC.Locomotora_Patente = objLocomotora.Patente;

                            var objCarro = _CarroService.GetByIdVM(car[0].IdCarro);
                            var objContenedor = _ContenedorService.GetByIdVM(car[0].IdContenedor);
                            var objStatu = _StatuService.GetByIdVM(car[0].IdStatusContenedor);
                            var objTag = _TagService.GetByIdVM(car[0].IdTag);

                            ResTrazabilidadC.Carro = objCarro.Descripcion;
                            ResTrazabilidadC.Carro_Patente= objCarro.Patente.ToString();
                            ResTrazabilidadC.Contenedor = objContenedor.Descripcion;
                            ResTrazabilidadC.Contenedor_Patente = objContenedor.Patente.ToString();
                            ResTrazabilidadC.Statu = objStatu.Descripcion;
                            ResTrazabilidadC.Tag = objTag.Descripcion;
                            ResTrazabilidadC.CodigoSello = car[0].CodigoSello;
                            ResTrazabilidadC.PesoNeto = car[0].PesoNeto.ToString();
                            ResTrazabilidadC.PesoBruto = car[0].PesoBruto.ToString();
                            ResTrazabilidadC.PesoTara = car[0].PesoTara.ToString();
                            ResTrazabilidadC.Sello = car[0].Sello.ToString();
                            lstResumenTrazabilidad.Add(ResTrazabilidadC);
                            #endregion Carros
                        }
                        else
                        {
                            ResTrazabilidadL.Carro = "";
                            ResTrazabilidadL.Carro_Patente = "";
                            ResTrazabilidadL.Contenedor = "";
                            ResTrazabilidadL.Contenedor_Patente = "";
                            ResTrazabilidadL.Statu = "";
                            ResTrazabilidadL.Tag = "";
                            ResTrazabilidadL.CodigoSello = "";
                            ResTrazabilidadL.PesoNeto = "0";
                            ResTrazabilidadL.PesoBruto = "0";
                            ResTrazabilidadL.PesoTara = "0";
                            ResTrazabilidadL.Sello = "0";
                            
                            lstResumenTrazabilidad.Add(ResTrazabilidadL);
                        }
                       
                        Ver = false;
                    }
                   
                    for(int ff=contCarro;ff<totCarro;ff++)
                    {
                        #region Carros
                        contCarro++;
                        List<TrazabilidadMovCarro> car = new List<TrazabilidadMovCarro>(item.TrazaMoviLoco_Carro);
                        ResumenTrazabilidad ResTrazabilidadF = new ResumenTrazabilidad();
                        //ResTrazabilidadF.Ruta = objRuta.Descripcion;
                        //ResTrazabilidadF.Cliente = objCliente.Nombre;
                        //ResTrazabilidadF.Celular_Cliente = objCliente.Celular.ToString();
                        //ResTrazabilidadF.FechaRegistro = item.FechaRegistro.ToLongDateString();
                        //ResTrazabilidadF.FechaInicio = item.FechaInico.ToLongDateString();
                        //ResTrazabilidadF.FechaCierre = item.FechaCierre.ToLongDateString();
                        //ResTrazabilidadF.Rut_Conductor = objConductor.Rut;
                        //ResTrazabilidadF.Conductor = objConductor.Nombres + " " + objConductor.Apellidos;
                        //ResTrazabilidadF.Celular_Conductor = objConductor.Celular;
                        //ResTrazabilidadF.Observacion = item.Observacion;
                        //ResTrazabilidadF.Locomotora = strDescripcionLocomotora;
                        //ResTrazabilidadF.Locomotora_Patente = strPatenteLocomotora;

                        ResTrazabilidadF.Ruta = objRuta.Descripcion;
                        ResTrazabilidadF.Cliente = objCliente.Nombre;
                        ResTrazabilidadF.Celular_Cliente = objCliente.Celular.ToString();
                        ResTrazabilidadF.FechaRegistro = item.FechaRegistro.ToLongDateString();
                        ResTrazabilidadF.FechaInicio = item.FechaInico.ToLongDateString();
                        ResTrazabilidadF.FechaCierre = item.FechaCierre.ToLongDateString();
                        ResTrazabilidadF.Rut_Conductor = objConductor.Rut;
                        ResTrazabilidadF.Conductor = objConductor.Nombres + " " + objConductor.Apellidos;
                        ResTrazabilidadF.Celular_Conductor = objConductor.Celular;
                        ResTrazabilidadF.Observacion = item.Observacion;
                        ResTrazabilidadF.Locomotora = "";
                        ResTrazabilidadF.Locomotora_Patente = "";

                        var objCarro = _CarroService.GetByIdVM(car[ff].IdCarro);
                        var objContenedor = _ContenedorService.GetByIdVM(car[ff].IdContenedor);
                        var objStatu = _StatuService.GetByIdVM(car[ff].IdStatusContenedor);
                        var objTag = _TagService.GetByIdVM(car[ff].IdTag);

                        ResTrazabilidadF.Carro = objCarro.Descripcion;
                        ResTrazabilidadF.Carro_Patente = objCarro.Patente.ToString();
                        ResTrazabilidadF.Contenedor = objContenedor.Descripcion;
                        ResTrazabilidadF.Contenedor_Patente = objContenedor.Patente.ToString();
                        ResTrazabilidadF.Statu = objStatu.Descripcion;
                        ResTrazabilidadF.Tag = objTag.Descripcion;
                        ResTrazabilidadF.CodigoSello = car[ff].CodigoSello;
                        ResTrazabilidadF.PesoNeto = car[ff].PesoNeto.ToString();
                        ResTrazabilidadF.PesoBruto = car[ff].PesoBruto.ToString();
                        ResTrazabilidadF.PesoTara = car[ff].PesoTara.ToString();
                        ResTrazabilidadF.Sello = car[ff].Sello.ToString();
                        lstResumenTrazabilidad.Add(ResTrazabilidadF);
                        #endregion Carros
                    }
                }
                else
                {
                    
                    ResTrazabilidad.Ruta = objRuta.Descripcion;
                    ResTrazabilidad.Cliente = objCliente.Nombre;
                    ResTrazabilidad.Celular_Cliente = objCliente.Celular.ToString();
                    ResTrazabilidad.FechaRegistro = item.FechaRegistro.ToLongDateString();
                    ResTrazabilidad.FechaInicio = item.FechaInico.ToLongDateString();
                    ResTrazabilidad.FechaCierre = item.FechaCierre.ToLongDateString();
                    ResTrazabilidad.Rut_Conductor = objConductor.Rut;
                    ResTrazabilidad.Conductor = objConductor.Nombres + " " + objConductor.Apellidos;
                    ResTrazabilidad.Celular_Conductor = objConductor.Celular;
                    ResTrazabilidad.Observacion = item.Observacion;
                    ResTrazabilidad.Locomotora = "";
                    ResTrazabilidad.Locomotora_Patente = "";
                    ResTrazabilidad.Carro = "";
                    ResTrazabilidad.Carro_Patente = "";
                    ResTrazabilidad.Contenedor = "";
                    ResTrazabilidad.Contenedor_Patente = "";
                    ResTrazabilidad.Statu = "";
                    ResTrazabilidad.Tag = "";
                    ResTrazabilidad.CodigoSello = "";
                    ResTrazabilidad.PesoNeto = "0";
                    ResTrazabilidad.PesoBruto = "0";
                    ResTrazabilidad.PesoTara = "0";
                    ResTrazabilidad.Sello = "0";
                }
                if (Ver)
                { lstResumenTrazabilidad.Add(ResTrazabilidad); }

            }

            try
            {
                return Json(lstResumenTrazabilidad, JsonRequestBehavior.AllowGet);
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }



        //public ActionResult ListResumenGeneral()
        //{
        //    //ViewBag.Stations = this.GetStations();
        //    ViewBag.Stations = this.GetBases();
        //    ViewBag.Persona = this.GetPersonas();

        //    var tripers = _TripulantePersonaService.GetViewModelList();
        //    var trip = _TripulanteService.GetViewModelList();

        //    var act = _ActividadService.GetViewModelList();
        //    var tripJornada = new List<Tripulante>();
        //    var tripPersona = new List<TripulantePersona>();

        //    return View(tripJornada);
        //}

     
    }
}