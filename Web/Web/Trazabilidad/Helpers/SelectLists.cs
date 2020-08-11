namespace Trazabilidad.Helpers
{
    using Microsoft.Azure.ActiveDirectory.GraphClient;
    using Trazabilidad.Models;
    using Resources.Strings;
    using Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public static class SelectLists
    {
        //public static SelectList GetStations(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IEstacionService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null
        //    var stations = srvc.GetViewModelList().Where(e => e.Deshabilitado == false)
        //        .Select(sta => new { sta.Id, Description = $"{sta.Codigo} - {sta.Nombre}" }).ToList();
        //    return new SelectList(stations, "Id", "Description");
        //}

        //public static SelectList GetAllStations(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IEstacionService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null

        //    var stations = srvc.GetViewModelList()
        //        .Select(sta => new { sta.Id, Description = $"{sta.Codigo} - {sta.Nombre}" }).ToList();

        //    return new SelectList(stations, "Id", "Description");
        //}

        //public static SelectList GetBases(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IEstacionService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null

        //    var stations = srvc.GetViewModelList()
        //        .Select(sta => new { sta.Id, Description = $"{sta.Codigo} - {sta.Nombre}" }).ToList().Take(200);

        //    return new SelectList(stations, "Id", "Description");
        //}
        //public static SelectList GetPersonas(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<ITripulante_PersonaService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null

        //    var stations = srvc.GetViewModelList()
        //        .Select(sta => new { sta.Id, sta.Rut, Nombre = $"{sta.Nombre}", Estacion = $"{sta.Base}" }).ToList();

        //    return new SelectList(stations, "Id",/* "Rut",*/ "Nombre", "Estacion");


        //}
        //public static SelectList GetNewsReasons(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<INovedadService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null

        //    //var news = srvc.GetViewModelList()
        //    //    .Select(@new => new { @new.Reason, Razon = $"{@new.Reason} " }).ToList();

        //    string[] Razon = new string[] { "Problemas con la carga", "Accidente a Personal",
        //        "Accidente a terceros", "Ingreso Storage", "Carpas", "Carros", "Vías y Comunicaciones", "IPA" };

        //    return new SelectList(Razon);
        //}

        //public static SelectList GetTrains(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<ITrenService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null

        //    var Trains = srvc.GetViewModelList()
        //        .Select(sta => new { sta.Id, Description = $"{sta.Tren_Concatenado}" }).ToList();

        //    return new SelectList(Trains, "Id", "Description");
        //}

        //public static SelectList GetClients(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IClientService>();

        //    if (srvc == null) { }
        //    //TODO: If null

        //    var clients = srvc.GetViewModelList().Select(cl =>
        //        new { cl.Id, Description = $"{cl.Code} - {cl.Name}" }).ToList();

        //    return new SelectList(clients, "Id", "Description");
        //}

        //public static SelectList GetServices(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IServicioService>();

        //    if (srvc == null) { }
        //    //TODO: If null

        //    var services = srvc.GetViewModel()
        //    .Select(srv => new { srv.Id, Description = $"{srv.Codigo}" }).ToList();
        //    return new SelectList(services, "Id", "Description");
        //}

        //public static SelectList GetPatios(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IServicioService>();

        //    if (srvc == null) { }
        //    //TODO: If null

        //    var services = srvc.GetViewModel()
        //    .Select(srv => new { srv.Id, Description = $"{srv.Codigo}" }).ToList();
        //    return new SelectList(services, "Id", "Description");
        //}

        public async static Task<SelectList> GetADUsers(this IController controller)
        {
            //TODO: Fix this.
            try
            {
                var ids = new string[] { "425e8c08-b3d7-4367-af6e-8dc9780c5e9f", "3c7bd12d-41e7-4d8f-bfaa-ab592bd4030d", "0f15f548-706b-434d-8759-00dae6d589b1" };

                var users = new List<IUser>();
                foreach (var id in ids)
                {
                    var u = await AzureOperations.GetUsersFromAD(id);
                    users.AddRange(u);
                }

                var adUsers = users.Distinct().Select(srv => new { Id = srv.ObjectId, Name = srv.DisplayName }).ToList();

                return new SelectList(adUsers, "Id", "Name");
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //public async static Task<SelectList> GetCrewmen(this IController controller)
        //{
        //    //TODO: Fix this.
        //    try
        //    {

        //        var users = new List<IUser>();
        //        var u = await AzureOperations.GetCrewmen();
        //        users.AddRange(u);

        //        var adUsers = users.Distinct().Select(srv => new { Id = srv.ObjectId, Name = srv.DisplayName }).ToList();

        //        return new SelectList(adUsers, "Id", "Name");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }
        //}

        //public static SelectList GetLocomotives(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<ILocomotoraService>();

        //    if (srvc == null) { }
        //    //TODO: If null

        //    var services = srvc.GetViewModelList()
        //        .Select(loc => new { loc.Id, Description = loc.Patente }).Where(l => l.Id != 9999).ToList();

        //    return new SelectList(services, "Id", "Description");
        //}

        //public static SelectList GetTypeLocomotive(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<ILocomotoraService>();

        //    if (srvc == null) { }
        //    //    //TODO: If null

        //    //var types = srvc.GetViewModelList()
        //    //    .Select(loc => new { Type = loc.Type }).ToList();

        //    string[] tipos = new string[] { "Diesel", "Electrica" };

        //    return new SelectList(tipos);
        //}

        //public static SelectList GetFestivo(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IFestivoService>();

        //    if (srvc == null) { }
        //    var festivo = srvc.GetViewModelList()
        //    .Select(sta => new { sta.Id }).ToList();
        //    return new SelectList(festivo, "Id");
        //}


        //public static SelectList GetTripulantePersona(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<ITripulante_PersonaService>();

        //    if (srvc == null) { }
        //    var tripulante = srvc.GetViewModelList()
        //    .Select(sta => new { sta.Id }).ToList();
        //    return new SelectList(tripulante, "Id");
        //}

        //Nacional, Administrativos, Los Andes
        public static SelectList getSindicatos(this IController controller)
        {
            string[] tipos = new string[] { "Nacional", "Administrativo", "Los Andes" };

            return new SelectList(tipos);
        }

        public static SelectList getCargo(this IController controller)
        {
            string[] tipos = new string[] { ViewModels.Enum.Cargo.TripulantePatio.ToString(), ViewModels.Enum.Cargo.TripulanteRuta.ToString(), ViewModels.Enum.Cargo.JefedeTren.ToString(), ViewModels.Enum.Cargo.AyudantedeMaquinista.ToString() };

            return new SelectList(tipos);
        }

        public static SelectList getMotivo(this IController controller)
        {
            string[] Motivos = new string[] { "Sin Justificar", "Vacaciones", "Licencia Médica", "Permiso Sindical", "Mutual", "Devolución Festival" };

            return new SelectList(Motivos);
        }

        //public static SelectList GetAllStationsName(this IController controller)
        //{
        //    var srvc = DependencyResolver.Current.GetService<IEstacionService>();
        //    if (srvc == null) { }
        //    //    //TODO: If null
        //    var stations = srvc.GetViewModelList()
        //        .Select(sta => new { sta.Id, Description = $"{sta.Nombre.Trim().ToLower().Replace(' ', '-')}" }).ToList();
        //    return new SelectList(stations, "Id", "Description");
        //}

    }
}