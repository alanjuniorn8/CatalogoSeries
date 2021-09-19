using System;
using System.Collections.Generic;
using DIO.Series.Models;
using DIO.Series.Repositories.Interfaces;

namespace DIO.Series.Repositories
{
    public class SerieRepository : IRepository<Serie>
    {
        
        private List<Serie> Series = new List<Serie>();

        public List<Serie> GetAll()
        {
            return Series;
        }

        public Serie GetById(Guid id)
        {
            return Series.Find(s => s.Id == id);;
        }
        public Serie Create(Serie novaSerie)
        {
            Series.Add(novaSerie);
            return novaSerie;
        }

        public bool Update(Guid id, Serie serieAtualizada)
        {
            Serie serie = Series.Find(s => s.Id == id);
            if (serie == null) return false;

            serie.Genero = serieAtualizada.Genero;
            serie.Titulo = serieAtualizada.Titulo;
            serie.Sinopse = serieAtualizada.Sinopse;
            serie.AnoLancamento = serieAtualizada.AnoLancamento;

            return true;
        }

        public bool Delete(Guid id)
        {
            var SerieToRemove = Series.Find(s => s.Id == id);
            if (SerieToRemove == null) return false;
            
            return Series.Remove(SerieToRemove);
        }

    }
}