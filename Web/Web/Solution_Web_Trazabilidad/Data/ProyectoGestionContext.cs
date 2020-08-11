namespace Data
{
    using Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProyectoGestionContext : DbContext
    {
        private const string ConnectionStringName = "DefaultConnection";

        public ProyectoGestionContext() : base(ConnectionStringName)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new Entities.UserTokenCache());

            //nuevo modelo
            //modelBuilder.Configurations.Add(new Entities.Itinerario());

            //modelBuilder.Entity<Itinerario>().Ignore(p => p.Id_Servicio);
            //modelBuilder.Entity<Itinerario>().Ignore(p => p.Id_Destino);
            //modelBuilder.Entity<Itinerario>().Ignore(p => p.Id_Origen);

            //modelBuilder.Configurations.Add(new Entities.Actividad());
       
            //modelBuilder.Configurations.Add(new Entities.Estacion());
            //modelBuilder.Configurations.Add(new Entities.Festivo());
            //modelBuilder.Configurations.Add(new Entities.Festivo_Estacion());
            //modelBuilder.Configurations.Add(new Entities.Gps());
            //modelBuilder.Configurations.Add(new Entities.Jornada());
            
            //modelBuilder.Configurations.Add(new Entities.Mensaje());
            //modelBuilder.Configurations.Add(new Entities.ReglasDeNegocio());
            //modelBuilder.Configurations.Add(new Entities.Patio());
            //modelBuilder.Configurations.Add(new Entities.Programacion());

            //modelBuilder.Configurations.Add(new Entities.Servicio());
            //modelBuilder.Configurations.Add(new Entities.Servicio_Cliente());
            //modelBuilder.Configurations.Add(new Entities.Tarea_Patio());
            //modelBuilder.Configurations.Add(new Entities.Tiempo_Hapa());
            //modelBuilder.Configurations.Add(new Entities.Tramo());
            //modelBuilder.Configurations.Add(new Entities.Tramo_Itinerario());
            //modelBuilder.Configurations.Add(new Entities.Tren());
            //modelBuilder.Configurations.Add(new Entities.Tren_Locomotora());
            //modelBuilder.Configurations.Add(new Entities.Tren_Tramo());
            //modelBuilder.Configurations.Add(new Entities.Tripulante());
            //modelBuilder.Configurations.Add(new Entities.Tripulante_Persona());
            //modelBuilder.Configurations.Add(new Entities.Tripulante_Pareja());
            //modelBuilder.Configurations.Add(new Entities.Viatico());
            //modelBuilder.Configurations.Add(new Entities.H_Tren_Tramo());
            //modelBuilder.Configurations.Add(new Entities.Ausencia());
            //modelBuilder.Configurations.Add(new Entities.Novedad());
            //modelBuilder.Configurations.Add(new Entities.HapaTripulante());
          
            //modelBuilder.Configurations.Add(new Entities.Log());
            modelBuilder.Configurations.Add(new Entities.Carro());
            modelBuilder.Configurations.Add(new Entities.Tag());
            modelBuilder.Configurations.Add(new Entities.Statu());
            modelBuilder.Configurations.Add(new Entities.Contenedor());
            modelBuilder.Configurations.Add(new Entities.Cliente());
            modelBuilder.Configurations.Add(new Entities.Ruta());
            modelBuilder.Configurations.Add(new Entities.Locomotora());
            modelBuilder.Configurations.Add(new Entities.Conductor());
            modelBuilder.Configurations.Add(new Entities.Trazabilidad());
            modelBuilder.Configurations.Add(new Entities.TrazabilidadMovLocomotora());
            modelBuilder.Configurations.Add(new Entities.TrazabilidadMovCarro());
        }

        public override int SaveChanges()
        {
            AddTimeStamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            AddTimeStamps();
            return base.SaveChangesAsync();
        }

        private void AddTimeStamps()
        {
            DateTime dt = new DateTime();
            var info = TimeZoneInfo.FindSystemTimeZoneById("Pacific SA Standard Time");
            DateTimeOffset localServerTime = DateTimeOffset.Now;
            DateTimeOffset localTime = TimeZoneInfo.ConvertTime(localServerTime, info);

            dt = localTime.DateTime;

            //var dateStr = DateTime.UtcNow.ToString();
            //DateTime convertedDate = DateTime.SpecifyKind(DateTime.Parse(dateStr), DateTimeKind.Utc);
            //var kind = convertedDate.Kind; // will equal DateTimeKind.Utc
            //DateTime dt = convertedDate.ToLocalTime();

            var entities = ChangeTracker.Entries().Where(ent => ent.Entity is Domain.Extensions.BaseModel && (ent.State == EntityState.Added || ent.State == EntityState.Modified));

            foreach (var ent in entities)
            {
                if (ent.State == EntityState.Added)
                    ((Domain.Extensions.BaseModel)ent.Entity).Created = dt;
                ((Domain.Extensions.BaseModel)ent.Entity).Updated = dt;
            }
        }

        //Modelo viejo con Jorge
        //public DbSet<Client> Clients { get; set; }
        //public DbSet<Service> Services { get; set; }
        //public DbSet<Schedule> Schedules { get; set; }
        //public DbSet<Route> Routes { get; set; }
        //public DbSet<Estacion> Estacions { get; set; }
        //public DbSet<TravelTime> TravelTimes { get; set; }
        //public DbSet<PassengerTravelTime> PassenverTravelTimes { get; set; }
        //public DbSet<Train> Trains { get; set; }
        //public DbSet<TrainGPSLog> TrainGPsLogs { get; set; }
        //public DbSet<TrainRoute> TrainRoutes { get; set; }
        //public DbSet<TrainRouteLocomotive> TrainRouteLocomotives { get; set; }
        //public DbSet<TrainRouteLocomotiveCrew> TrainRouteLocomotiveCrews { get; set; }
        //public DbSet<TrainRouteFreightCar> TrainRouteFreightCars { get; set; }
        //public DbSet<Absence> Absences { get; set; }
        //public DbSet<AbsenceReason> AbsenceReasons { get; set; }
        //public DbSet<TrainCrewman> Crewmen { get; set; }
        //public DbSet<Plan> Plans { get; set; }
        //public DbSet<Locomotive> Locomotives { get; set; }
        //public DbSet<News> News { get; set; }
        //public DbSet<UserTokenCache> UserTokenCacheList { get; set; }
        //public DbSet<Holiday> Holidays { get; set; }
        //public DbSet<HolidayEstacion> HolidayEstacions { get; set; }
        //Modelo Nuevo sin Jorge




        //public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Estacion> Estaciones { get; set; }
        //public DbSet<Festivo> Festivos { get; set; }
        //public DbSet<Festivo_Estacion> Festivo_Estaciones { get; set; }
        //public DbSet<Gps> Gpss { get; set; }
        //public DbSet<Itinerario> Itinerarios { get; set; }
        //public DbSet<Jornada> Jornadas { get; set; }
        //public DbSet<Locomotora> Locomotoras { get; set; }
        //public DbSet<Mensaje> Mensajes { get; set; }
        //public DbSet<ReglasDeNegocio> ReglasDeNegocios { get; set; }

        //public DbSet<Patio> Patios { get; set; }
        //public DbSet<Programacion> Programaciones { get; set; }
        //public DbSet<Ruta> Rutas { get; set; }
        //public DbSet<Servicio> Servicios { get; set; }
        //public DbSet<Servicio_Cliente> Servicio_Clientes { get; set; }

        //public DbSet<Tarea_Patio> Tareas_Patio { get; set; }
        //public DbSet<Tiempo_Hapa> Tiempos_Hapa { get; set; }
        //public DbSet<Tramo> Tramos { get; set; }
        //public DbSet<Tramo_Itinerario> Tramos_Itinerario { get; set; }
        //public DbSet<Tren> Trenes { get; set; }
        //public DbSet<Tren_Locomotora> Trenes_Locomotora { get; set; }
        //public DbSet<Tren_Tramo> Trenes_Tramo { get; set; }
        //public DbSet<Tripulante> Tripulantes { get; set; }
        //public DbSet<Tripulante_Persona> Tripulante_Personas { get; set; }
        //public DbSet<Tripulante_Pareja> Tripulante_Pareja { get; set; }
        //public DbSet<Viatico> Viaticos { get; set; }
        //public DbSet<H_Tren_Tramo> H_Tren_Tramos { get; set; }
        //public DbSet<Ausencia> Ausencias { get; set; }
        //public DbSet<Novedad> Novedades { get; set; }
        //public DbSet<HapaTripulante> HapaTripulantes { get; set; }
        //public DbSet<Log> Logs { get; set; }
        public DbSet<Carro> Carros{ get; set; }

        //public DbSet<Trazabilidad> Trazabilidads { get; set; }
    }
}