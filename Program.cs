using System;

namespace DIO.Cadastros
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
						ListarConteudo();
						break;
					case "2":
						InserirConteudo();
						break;
					case "3":
						AtualizarConteudo();
						break;
					case "4":
						ExcluirConteudo();
						break;
					case "5":
						VisualizarConteudo();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.WriteLine("Volte sempre!");
			Console.ReadLine();
        }

        private static void ExcluirConteudo()
		{
			Console.Write("Digite o id do titulo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarConteudo()
		{
			Console.Write("Digite o id do titulo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var conteudo = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(conteudo);
		}

        private static void AtualizarConteudo()
		{
			Console.Write("Digite o id do titulo: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			Console.WriteLine("Filme ou Série?");
			string entradaTipoTitulo = Console.ReadLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write($"Digite o Título do(a) {entradaTipoTitulo}: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write($"Digite o Ano de Início do(a) {entradaTipoTitulo}: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write($"Digite a Descrição do(a) {entradaTipoTitulo}: ");
			string entradaDescricao = Console.ReadLine();

			Conteudo atualizaConteudo = new Conteudo(id: indiceSerie,
										tipo: entradaTipoTitulo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaConteudo);
		}
        private static void ListarConteudo()
		{
			Console.WriteLine("Listar títulos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum título cadastrado.");
				return;
			}

			foreach (var conteudo in lista)
			{
                var excluido = conteudo.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", conteudo.retornaId(), conteudo.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirConteudo()
		{
			Console.WriteLine("Inserir um novo título ao catalogo");
			Console.Write("Filme ou Série: ");
			string entradaTipoTitulo = Console.ReadLine();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write($"Digite o Título do(a) {entradaTipoTitulo}: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write($"Digite o Ano de Início do(a) {entradaTipoTitulo}: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write($"Digite a Descrição do(a) {entradaTipoTitulo}: ");
			string entradaDescricao = Console.ReadLine();

			Conteudo novoConteudo = new Conteudo(id: repositorio.ProximoId(),
										tipo: entradaTipoTitulo,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoConteudo);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Vídeos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Conteúdo");
			Console.WriteLine("2- Inserir um novo título");
			Console.WriteLine("3- Atualizar título");
			Console.WriteLine("4- Excluir");
			Console.WriteLine("5- Visualizar título");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
