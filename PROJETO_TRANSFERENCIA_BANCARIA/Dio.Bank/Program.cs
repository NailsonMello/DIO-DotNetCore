using Dio.Bank.Classes;
using Dio.Bank.Domain.Services;
using Dio.Bank.Domain.Services.Interfaces;
using Dio.Bank.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var acoesContaService = serviceProvider.GetService<IAcoesContaService>();
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas(acoesContaService);
                        break;
                    case "2":
                        InserirConta(acoesContaService);
                        break;
                    case "3":
                        Transferir(acoesContaService);
                        break;
                    case "4":
                        Sacar(acoesContaService);
                        break;
                    case "5":
                        Depositar(acoesContaService);
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
            Console.ReadLine();
        }

        private static void Depositar(IAcoesContaService acoesContaService)
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            acoesContaService.Depositar(indiceConta, valorDeposito);
        }

        private static void Sacar(IAcoesContaService acoesContaService)
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            acoesContaService.Sacar(indiceConta, valorSaque);
        }

        private static void Transferir(IAcoesContaService acoesContaService)
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            acoesContaService.Transferir(indiceContaOrigem, indiceContaDestino, valorTransferencia);
        }

        private static void InserirConta(IAcoesContaService acoesContaService)
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            if (entradaTipoConta < 1 || entradaTipoConta > 2)
            {
                Console.Write("Tipo de conta invalida, tente novamente... ");
                Console.WriteLine();
                return;
            }

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            acoesContaService.InserirConta(entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
        }

        private static void ListarContas(IAcoesContaService acoesContaService)
        {
            Console.WriteLine("Listar contas");

            List<Conta> listContas = acoesContaService.ListarContas();
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine();
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAcoesContaService, AcoesContaService>()
                .AddScoped<IAcoesContaRepository, AcoesContaRepository>();
        }
    }
}
