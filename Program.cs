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

                        VisualizarSerie();
                        break;

                    case 3:

                        CadastrarSerie();
                        break;

                    case 4:

                        AtualizarSerie();
                        break;

                    case 5: 

                        ExcluirSerie();
                        break;

                    default:

                        Console.WriteLine("Por favor escolha uma das opções listada");
                        break;
                }

                userChoice = GetUserInput();

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

        private static void InvalidId()
        {
            Console.WriteLine("O Id informado não é válido");
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

        private static void VisualizarSerie()
        {
             try
            {
                Console.WriteLine("Informe o Id da Série que deseja visualizar: ");
                var idInput = Guid.Parse(Console.ReadLine());

                var serieRetornada = repository.GetById(idInput);

                if (serieRetornada == null) 
                {
                    Console.WriteLine("Série não encontrada!");
                    return;
                }

                Console.WriteLine(serieRetornada);
                

            }
            catch (FormatException e)
            {
                InvalidId();
            } 
        }

        private static void  CadastrarSerie()
        {   
            var novaSerie = PopulaSerie();

            var serieCriada = repository.Create(novaSerie);
            Console.WriteLine("Série criada com sucesso!");
            Console.WriteLine(serieCriada);


        }
        
        
        private static void AtualizarSerie()
        {
            Console.WriteLine("Informe o Id da Série que deseja atualizar: ");
            

            try
            {

                var idInput = Guid.Parse(Console.ReadLine());

                if(repository.GetById(idInput) != null){
                    
                    var serieAtualizada = PopulaSerie();
                    var sucesso = repository.Update(idInput, serieAtualizada);
                    
                    if(sucesso)
                    {
                        Console.WriteLine("Serie atualizada com sucesso!");
                        return;
                    } 

                    Console.WriteLine("Ocorreu um erro, tente novamente");
                    return;

                }
                else
                {
                    Console.WriteLine("Série não encontrada!");
                    return;
                }
            }
            catch (FormatException e)
            {
                InvalidId();
            } 
            
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da Série que deseja excluir: ");
            try
            {
                var idInput = Guid.Parse(Console.ReadLine());

                if (repository.Delete(idInput)) Console.WriteLine("A Série foi excluida do catalógo!");
            }
            catch (FormatException e)
            {
                InvalidId();
            }
        }

        private static Serie PopulaSerie()
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

            while(true){
                try{
                    
                    generoInput= Int32.Parse(Console.ReadLine());
                    var generoExiste = generosDisponiveis.Find(g => g.Equals(generoInput)) != 0;

                    if (generoExiste)  break;
                        
                    Console.WriteLine("Selecione um Gênero existente");
                                  
                }
                catch (FormatException e)
                {
                    InvalidOPeration();
                }
                
            }
            

            Console.WriteLine("Insira Título da Série: ");
            string tituloInput = Console.ReadLine();

            Console.WriteLine("Insira a Snopse da Série: ");
            string SinopseInput = Console.ReadLine();

            int anoInput = validaAno();

            Serie serie = new Serie
            (
                genero: (Genero)generoInput,
                titulo: tituloInput,
                sinopse: SinopseInput,
                anoLancamento: anoInput
            );

            return serie;
        }

        private static int validaAno()
        {
            Console.WriteLine("Insira o ano(número) de lançamento da série: ");
            int anoInput = 0;

            while(true)
            {
                try
                {
                    anoInput = Int32.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Selecione um ano no formato numérico");
                }
            }

            return anoInput;
        }
    }
}
