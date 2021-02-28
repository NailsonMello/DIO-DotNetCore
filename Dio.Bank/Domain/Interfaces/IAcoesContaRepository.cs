using Dio.Bank.Classes;
using System.Collections.Generic;

namespace Dio.Bank.Interfaces
{
    public interface IAcoesContaRepository
    {
        void Depositar(List<Conta> listContas, int indiceConta, double valorDeposito);
        void InserirConta(List<Conta> listContas, int entradaTipoConta, string entradaNome, double entradaSaldo, double entradaCredito);
        void ListarContas(List<Conta> listContas);
        void Sacar(List<Conta> listContas, int indiceConta, double valorSaque);
        void Transferir(List<Conta> listContas, int indiceContaOrigem, int indiceContaDestino, double valorTransferencia);
    }
}
