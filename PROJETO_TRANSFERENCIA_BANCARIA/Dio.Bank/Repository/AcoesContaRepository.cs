using Dio.Bank.Enum;
using Dio.Bank.Interfaces;
using System;
using System.Collections.Generic;

namespace Dio.Bank.Classes
{
    public class AcoesContaRepository : IAcoesContaRepository
    {
        private List<Conta> listContas = new List<Conta>();
        public void Depositar(int indiceConta, double valorDeposito)
        {
            listContas[indiceConta].Depositar(valorDeposito);
        }

        public void InserirConta(int entradaTipoConta, string entradaNome, 
                                double entradaSaldo, double entradaCredito)
        {
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        public List<Conta> ListarContas() => listContas;
 
        public void Sacar(int indiceConta, double valorSaque)
        {
            listContas[indiceConta].Sacar(valorSaque);
        }

        public void Transferir(int indiceContaOrigem, int indiceContaDestino, double valorTransferencia)
        {
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
    }
}
