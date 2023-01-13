/*
    Projeto:

    Crie um projeto em C# que leia os dados de um funcionário, informado pelo usuário
    O Funcionário será composto de Id, Nome, Cpf, Matricula e Data de Admissao e tambem
    deverá ter 1 Setor (Id, Nome) e Função (Id e Descricao) associados
    O programa deverá ler estes dados e gravados em arquivos de extensão JSON ou XML, 
    dependendo da escolha do usuário
*/

using ProjetoAula02.Entities;
using ProjetoAula02.Repositories;

namespace ProjetoAula02
{
    /// <summary>
    /// Classe de inicialização do projeto
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Método para execução da classe
        /// </summary>
        public static void Main(string[] args)
        {
            //imprimindo..
            Console.WriteLine("\n *** CADASTRO DE FUNCIONÁROS *** \n");

            //criando um objeto para funcionario
            var funcionario = new Funcionario();
            funcionario.Funcao = new Funcao();

            try
            {
                funcionario.Id = Guid.NewGuid();
                funcionario.Funcao.Id = Guid.NewGuid();

                Console.Write("INFORME O NOME DO FUNCIONÁRIO...: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("INFORME O CPF...................: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("INFORME A MATRÍCULA.............: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("INFORME A DATA DE ADMISSÃO......: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("INFORME A DESCRIÇÃO DA FUNÇÃO...: ");
                funcionario.Funcao.Descricao = Console.ReadLine();

                //imprimindo
                Console.WriteLine("\nDADOS DO FUNCIONÁRIO:");
                Console.WriteLine($"\tID............: {funcionario.Id}");
                Console.WriteLine($"\tNOME..........: {funcionario.Nome}");
                Console.WriteLine($"\tCPF...........: {funcionario.Cpf}");
                Console.WriteLine($"\tMATRICULA.....: {funcionario.Matricula}");
                Console.WriteLine($"\tDATA ADMISSÃO.: {funcionario.DataAdmissao}");
                Console.WriteLine($"\tID DA FUNÇÃO..: {funcionario.Funcao.Id}");
                Console.WriteLine($"\tDESCRIÇÃO.....: {funcionario.Funcao.Descricao}");

                Console.Write("\nESCOLHA (1)JSON ou (2)XML.....: ");
                var opcao = int.Parse(Console.ReadLine());

                //criando um objeto para a classe FuncionarioRepository
                var funcionarioRepository = new FuncionarioRepository();

                switch(opcao)
                {
                    case 1:
                        funcionarioRepository.ExportarJson(funcionario);
                        Console.WriteLine("\nARQUIVO JSON GRAVADO COM SUCESSO!");
                        break;

                    case 2:
                        funcionarioRepository.ExportarXml(funcionario);
                        Console.WriteLine("\nARQUIVO XML GRAVADO COM SUCESSO!");
                        break;

                    default:
                        Console.WriteLine("\nOPÇÃO INVÁLIDA.");
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("\nERRO DE VALIDAÇÃO:");
                Console.WriteLine(e.Message);

                Console.Write("\nDESEJA TENTAR NOVAMENTE? (S,N)..: ");
                var opcao = Console.ReadLine();

                if(opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear(); //limpar o texto do console
                    Main(args); //Recursividade
                }
                else
                {
                    Console.WriteLine("\nFIM!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFALHA AO EXECUTAR O PROGRAMA:");
                Console.WriteLine(e.Message);
            }

            //aguardar uma tecla para continuar..
            Console.ReadKey();
        }
    }
}