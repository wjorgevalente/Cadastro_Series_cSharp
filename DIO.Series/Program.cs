using System;
using System.Collections.Generic;
using DIO.Series.Classes;


namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch (opcaoUsuario)
               {
                   case "1":
                        ListarSeries();
                        break;
                   case "2":
                        InserirSerie();
                        break;
                   case "3":
                        AtualizarSerie();
                        break;
                   case "4":
                        ExcluirSerie();
                        break;
                   case "5":
                        VisualizarSerie();
                        break;
                   case "C":
                        Console.Clear();
                        break;

                   default:
                        throw new ArgumentOutOfRangeException();
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
            System.Console.WriteLine("Obrigado por utilizar nossos serviços!");
            System.Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie a ser excluida. ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));                
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, 
                                        genero:(Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }
        

        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {   
                var excluido = serie.retornaExcluido();
                
                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSerie()
        {
            System.Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));                
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de inicio da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                        genero:(Genero)entradaGenero, 
                                        titulo: entradaTitulo, 
                                        ano: entradaAno, 
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Curso GFT#5 ao seu dispor!");
            System.Console.WriteLine("Informe a opção desejada:");
            System.Console.WriteLine();

            System.Console.WriteLine("1- Listar séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("C- Limpar Tela");
            System.Console.WriteLine("X- Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
