using System;
using System.Collections.Generic;
using DIO.Series.Models;
using DIO.Series.Repositories;

namespace DIO.Series
{
    class Program
    {
        
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string userChoice = GetUserInput();

            while (userChoice.ToUpper() != "X")
            {   

                int userChoiceParsed = 0 ;

                try {

                    userChoiceParsed = Int32.Parse(userChoice);
                }
                catch (FormatException e)
                {
                    InvalidOPeration();
                }
                

                switch (userChoiceParsed)
                {
                    case 1:

                        ListarSeries();
                        break;

                    case 2:

                        //VisualizarSerie();
                        break;

                    case 3:

                        CadastrarSerie();
                        break;

                    case 4:

                        //AtualizarSerie();
                        break;

                    case 5: 

                        //ExcluirSerie();
                        break;

                    default:

                        InvalidOPeration();
                        break;
                }
            }
        }

        private static string GetUserInput()
        {
            Console.WriteLine("Informe qual ação deseja executar.");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Visualizar série");
            Console.WriteLine("3 - Cadastrar nova série");
            Console.WriteLine("4 - Atualizar série");
            Console.WriteLine("5 - Excluir série");
            Console.WriteLine("x - Sair");

            string choice = Console.ReadLine();
            return choice;
        }

        private static void InvalidOPeration()
        {
            Console.WriteLine("Opção escolhida não existe!");
        }

        private static void  ListarSeries()
        {
            var series = repository.GetAll();

            if (series.Count == 0) {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }

            foreach (var serie in series)
            {
                Console.WriteLine("{0} - {1}", serie, serie.Titulo);
            }
        }

        private static void  CadastrarSerie()
        {   
            List<int> generosDisponiveis = new List<int>();
            Console.WriteLine("Gêneros:");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                generosDisponiveis.Add(i);
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Escolha um Gênero conforme as opçoẽs acima: ");
            int generoInput = 0;
            try{
                
                generoInput= Int32.Parse(Console.ReadLine());
                
            }
            catch (FormatException e)
            {
                InvalidOPeration();
                CadastrarSerie();
            }

            var generoExiste = generosDisponiveis.Find(g => g.Equals(generoInput)) != null;

            if (!generoExiste)
            {
                Console.WriteLine("Selecione um Gênero existente");
                CadastrarSerie();
            }

            Console.WriteLine("Insira Título da Série: ");
            string tituloInput = Console.ReadLine();

            Console.WriteLine("Insira a Snopse da Série: ");
            string SinopseInput = Console.ReadLine();

            int anoInput = validaAno();

            Serie novaSerie = new Serie
            (
                genero: (Genero)generoInput,
                titulo: tituloInput,
                sinopse: SinopseInput,
                anoLancamento: anoInput
            );

            var serieCriada = repository.Create(novaSerie);
            Console.WriteLine("Série criada com sucesso!");
            Console.WriteLine(serieCriada);

        }

        static int validaAno()
        {
            Console.WriteLine("Insira o ano(número) de lançamento da série: ");
            int anoInput = 0;

            try{
                anoInput = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Selecione um ano no formato numérico");
                validaAno();
            }

            return anoInput;
        }
    }
}
