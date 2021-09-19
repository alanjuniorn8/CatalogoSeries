using System;

namespace DIO.Series.Classes
{
    public class Serie : SerieBase
    {

        public Genero Genero { get; set; }

        public string Titulo { get; set; }

        public string Sinopse { get; set; }

        public int AnoLancamento { get; set; }


        public Serie(Genero genero, string titulo, string sinopse, int anoLancamento){
            Genero = genero;
            Titulo = titulo;
            Sinopse = sinopse;
            AnoLancamento = anoLancamento;
        }

        public override string ToString()
        {
            return "Gênero: " + Genero + Environment.NewLine +
                    "Titulo: " + Titulo + Environment.NewLine +
                    "Sinopse: " + Sinopse + Environment.NewLine +
                    "Ano de Lançamento: " + AnoLancamento + Environment.NewLine;
        }
    }
    
}