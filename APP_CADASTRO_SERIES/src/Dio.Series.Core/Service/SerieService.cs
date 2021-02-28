using Dio.Series.Core.Domain.Entities;
using Dio.Series.Core.Interfaces;
using Dio.Series.Core.Service.Interfaces;
using System.Collections.Generic;

namespace Dio.Series.Core.Service
{
    public class SerieService : ISerieService
    {
        private readonly ISerieRepositorio _serieRepositorio;

        public SerieService(ISerieRepositorio serieRepositorio)
        {
            _serieRepositorio = serieRepositorio;
        }
        public void Atualiza(int id, Serie objeto) => _serieRepositorio.Atualiza(id, objeto);

        public void Exclui(int id) => _serieRepositorio.Exclui(id);
    
        public void Insere(Serie objeto) => _serieRepositorio.Insere(objeto);

        public List<Serie> Lista() => _serieRepositorio.Lista();

        public int ProximoId() => _serieRepositorio.ProximoId();

        public Serie RetornaPorId(int id) => _serieRepositorio.RetornaPorId(id);
    }
}
