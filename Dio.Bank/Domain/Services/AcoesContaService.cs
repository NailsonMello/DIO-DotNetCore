using Dio.Bank.Classes;
using Dio.Bank.Domain.Services.Interfaces;
using Dio.Bank.Interfaces;
using System.Collections.Generic;

namespace Dio.Bank.Domain.Services
{
    public class AcoesContaService : IAcoesContaService
    {
        private readonly IAcoesContaRepository _acoesContaRepository;

        public AcoesContaService(IAcoesContaRepository acoesContaRepository)
        {
            _acoesContaRepository = acoesContaRepository;
        }

        public void Depositar(List<Conta> listContas, int indiceConta, double valorDeposito)
        {
            _acoesContaRepository.Depositar(listContas, indiceConta, valorDeposito);
        }

        public void InserirConta(List<Conta> listContas, int entradaTipoConta, string entradaNome, 
                                    double entradaSaldo, double entradaCredito)
        {
            _acoesContaRepository.InserirConta(listContas, entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
        }

        public void ListarContas(List<Conta> listContas)
        {
            _acoesContaRepository.ListarContas(listContas);
        }

        public void Sacar(List<Conta> listContas, int indiceConta, double valorSaque)
        {
            _acoesContaRepository.Sacar(listContas, indiceConta, valorSaque);
        }

        public void Transferir(List<Conta> listContas, int indiceContaOrigem, int indiceContaDestino, double valorTransferencia)
        {
            _acoesContaRepository.Transferir(listContas, indiceContaOrigem, indiceContaDestino, valorTransferencia);
        }
    }
}
