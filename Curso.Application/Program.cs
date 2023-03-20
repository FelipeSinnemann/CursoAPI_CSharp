using Curso.Service.Interfaces;
using Curso.Repository.Repository;
using Org.BouncyCastle.Security;
using Curso.Service.Services;
using Curso.Domain.DTO;
using Curso.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Curso.Application
{
    internal class Program
    {
        private static TipoVeiculoRepository _tipoVeiculoRepository;
        private static VeiculoRepository _veiculoRepository;

        private static ITipoVeiculoService _tipoVeiculoService;
        private static IVeiculoService _veiculoService;
        static void Main(string[] args)
        {
            SetupProject();
            Menu();
        }

        private static void SetupProject()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionMysql = config["ConnectionStrings:CursoAppelSoft"].ToString();

            var optionsBuilder = new DbContextOptionsBuilder<CursoDBContext>();
            optionsBuilder.UseMySQL(connectionMysql);

            CursoDBContext context = new CursoDBContext(optionsBuilder.Options);

            _tipoVeiculoRepository = new TipoVeiculoRepository(context);
            _veiculoRepository = new VeiculoRepository();

            _tipoVeiculoService = new TipoVeiculoService(_tipoVeiculoRepository);
            _veiculoService = new VeiculoService(_veiculoRepository);
        }
        private static void Menu()
        {
            var opcaoSelecionada = "";
            do
            {
                Console.WriteLine("Selecione a opção desejada");
                Console.WriteLine();

                Console.WriteLine("VEÍCULOS");
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Cadastrar");
                Console.WriteLine("3 - Atualizar");
                Console.WriteLine("4 - Buscar");
                Console.WriteLine("5 - Excluir");
                Console.WriteLine();

                Console.WriteLine("TIPOS DE VEÍCULO");
                Console.WriteLine("6 - Listar");
                Console.WriteLine("7 - Cadastrar");
                Console.WriteLine("8 - Atualizar");
                Console.WriteLine("9 - Excluir");

                Console.WriteLine("10- Sair");
                Console.WriteLine();
                Console.Write("Opção: ");
                opcaoSelecionada = Console.ReadLine();
                switch (opcaoSelecionada)
                {
                    case "1":
                        {
                            ListarVeiculos();
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            CadastrarVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            //AtualizarVeiculo();
                            break;
                        }
                    case "4":
                        {
                            //BuscarVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            //ExcluirVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            ListarTiposVeiculos();
                            Console.ReadLine();
                            break;
                        }
                    case "7":
                        {
                            CadastrarTipoVeiculo();
                            Console.ReadLine();
                            break;
                        }
                    case "8":
                        {
                            AtualizarTipoVeiculo();
                            break;
                        }
                    case "9":
                        {
                            ExcluirTipoVeiculo();
                            break;
                        }
                    case "10":
                        {
                            Console.WriteLine("Até mais");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Opção inválida");
                            break;
                        }
                }


            } while (opcaoSelecionada != "10");
        }

        private static void ExcluirTipoVeiculo()
        {
            try
            {
                Console.Write("Informe o código do tipo: ");
                var codigoTipo = Convert.ToInt64(Console.ReadLine());

                var tipoExcluir = BuscarTipoVeiculo(codigoTipo);
                if (tipoExcluir != null && tipoExcluir.id > 0)
                {
                    Console.WriteLine($"Tem certeza que deseja excluir o tipo {tipoExcluir.descricao} ? S/N: ");

                    var opcao = Console.ReadLine().ToUpper();
                    if (opcao == "S")
                    {
                        bool excluido = _tipoVeiculoService.Delete(tipoExcluir.id);
                        if (excluido)
                        {
                            Console.WriteLine("Tipo excluído com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível realizar a operação");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada");
                    }

                }
                else
                {
                    Console.WriteLine("Tipo não encontrado.");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        static void ListarVeiculos()
        {
            try
            {
                List<VeiculoDTO> listVeiculosDTO = _veiculoService.List();
                foreach (var veiculo in listVeiculosDTO)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"Id: {veiculo.id}");
                    Console.WriteLine($"Marca: {veiculo.marca}");
                    Console.WriteLine($"Modelo: {veiculo.modelo}");
                    Console.WriteLine($"Placa: {veiculo.placa}");
                    Console.WriteLine($"Cor: {veiculo.cor}");
                    Console.WriteLine($"Ano: {veiculo.ano}");
                    Console.WriteLine($"Tipo: {veiculo.tipo}");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        private static void CadastrarVeiculo()
        {
            try
            {
                VeiculoDTO veiculoDTO = new VeiculoDTO();

                Console.Write("Marca: ");
                veiculoDTO.marca = Console.ReadLine();

                Console.Write("Modelo: ");
                veiculoDTO.modelo = Console.ReadLine();

                Console.Write("Placa: ");
                veiculoDTO.placa = Console.ReadLine();

                Console.Write("Cor: ");
                veiculoDTO.cor = Console.ReadLine();

                Console.Write("Ano: ");
                veiculoDTO.ano = (int)(Convert.ToInt32(Console.ReadLine()));

                Console.Write("Tipo: ");
                veiculoDTO.tipo = (int)(Convert.ToInt32(Console.ReadLine()));

                veiculoDTO = _veiculoService.Insert(veiculoDTO);
                if (veiculoDTO != null && veiculoDTO.id > 0)
                {
                    Console.WriteLine($"Veículo cadastrado com sucesso: {veiculoDTO.id} - {veiculoDTO.marca} {veiculoDTO.modelo}");
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        static void ListarTiposVeiculos()
        {
            try
            {
                List<TipoVeiculoDTO> listTiposDTO = _tipoVeiculoService.List();
                foreach (var tipoVeiculo in listTiposDTO)
                {
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine($"{tipoVeiculo.id} - {tipoVeiculo.descricao}");
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        private static void CadastrarTipoVeiculo()
        {
            try
            {
                TipoVeiculoDTO tipoVeiculoDTO = new TipoVeiculoDTO();

                Console.Write("Descrição: ");
                tipoVeiculoDTO.descricao = Console.ReadLine();

                tipoVeiculoDTO = _tipoVeiculoService.Insert(tipoVeiculoDTO);
                if (tipoVeiculoDTO != null && tipoVeiculoDTO.id > 0)
                {
                    Console.WriteLine($"Tipo cadastrado com sucesso: {tipoVeiculoDTO.id} - {tipoVeiculoDTO.descricao}");
                }

            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        private static void AtualizarTipoVeiculo()
        {
            try
            {
                Console.Write("Informe o código do tipo: ");
                var codigoTipo = Convert.ToInt64(Console.ReadLine());

                var tipoAtualizar = BuscarTipoVeiculo(codigoTipo);
                Console.WriteLine("Dados do tipo atual");
                Console.WriteLine($"Id: {tipoAtualizar.id}");
                Console.WriteLine($"Descrição: {tipoAtualizar.descricao}");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("Dados para atualizar");
                Console.Write("Descrição: ");
                tipoAtualizar.descricao = Console.ReadLine();
                tipoAtualizar = _tipoVeiculoService.Update(tipoAtualizar);

                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Dados atualizadosl");
                Console.WriteLine($"Id: {tipoAtualizar.id}");
                Console.WriteLine($"Descrição: {tipoAtualizar.descricao}");
            }
            catch (Exception erro)
            {
                Console.WriteLine($"Erro: {erro.Message}");
            }

        }

        private static TipoVeiculoDTO BuscarTipoVeiculo(long codigoTipo)
        {
            return _tipoVeiculoService.Get(codigoTipo);
        }
    }
}