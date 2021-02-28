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

        public void Depositar(int indiceConta, double valorDeposito)
        {
            _acoesContaRepository.Depositar(indiceConta, valorDeposito);
        }

        public void InserirConta(int entradaTipoConta, string entradaNome, 
                                    double entradaSaldo, double entradaCredito)
        {
            _acoesContaRepository.InserirConta(entradaTipoConta, entradaNome, entradaSaldo, entradaCredito);
        }

        public List<Conta> ListarContas() => _acoesContaRepository.ListarContas();

        public void Sacar(int indiceConta, double valorSaque)
        {
            _acoesContaRepository.Sacar(indiceConta, valorSaque);
        }

        public void Transferir(int indiceContaOrigem, int indiceContaDestino, double valorTransferencia)
        {
            _acoesContaRepository.Transferir(indiceContaOrigem, indiceContaDestino, valorTransferencia);
        }
    }
}
