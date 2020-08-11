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



    public class TrazaUbicacionCarroService : BaseService<TrazaUbicacionCarro>, ITrazaUbicacionCarroService
    {
        public TrazaUbicacionCarroService(IBaseRepository<TrazaUbicacionCarro> baseRepo) : base(baseRepo)
        {
        }

        public IEnumerable<ViewModels.Models.TrazaUbicacionCarro> GetViewModelList()
        {
            try
            {
                var x = Mapper.Map<IEnumerable<ViewModels.Models.TrazaUbicacionCarro>>
                    (_repository.Get()) ?? Enumerable.Empty<ViewModels.Models.TrazaUbicacionCarro>();
                //(_repository.GetWithoutTracking()) ?? Enumerable.Empty<ViewModels.Models.Trazabilidad>();   //agregado.

                return x;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ViewModels.Custom.TrainActivo> ActivosforMap()
        {

            var aaaa = _repository.Get(xx => xx.DescripcionUbiRuta, yy => yy.DescripcionUbiCarro).ToList().OrderByDescending(s => s.Id).GroupBy(e => e.DescripcionUbiCarro.Patente);
            var aaa = aaaa.Select(x => x.FirstOrDefault());
            var latestReports = new List<ViewModels.Custom.TrainActivo>();

            foreach (var item in aaa)
            {
                ViewModels.Custom.TrainActivo aa = new ViewModels.Custom.TrainActivo();
                aa.id = item.Id;
                aa.Patente = item.DescripcionUbiCarro.Patente.ToString();
                aa.location = item.DescripcionUbiRuta.Sigla_Codelco;
                aa.activo = "1";
                aa.Longitude = item.DescripcionUbiRuta.Longitud;
                aa.Latitude = item.DescripcionUbiRuta.Latitud;
                latestReports.Add(aa);
                //}
            }

            return latestReports ?? Enumerable.Empty<ViewModels.Custom.TrainActivo>();
        }

        public ViewModels.Models.TrazaUbicacionCarro GetByIdVM(int id)
           => Mapper.Map<ViewModels.Models.TrazaUbicacionCarro>
               (_repository.Get().FirstOrDefault(y => y.Id == id));

    }
}
