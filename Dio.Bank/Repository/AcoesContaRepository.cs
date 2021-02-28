using Dio.Bank.Enum;
using Dio.Bank.Interfaces;
using System;
using System.Collections.Generic;

namespace Dio.Bank.Classes
{
    public class AcoesContaRepository : IAcoesContaRepository
    {
        public void Depositar(List<Conta> listContas, int indiceConta, double valorDeposito)
        {
            listContas[indiceConta].Depositar(valorDeposito);
        }

        public void InserirConta(List<Conta> listContas, int entradaTipoConta, string entradaNome, 
                                double entradaSaldo, double entradaCredito)
        {
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        public void ListarContas(List<Conta> listContas)
        {
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        public void Sacar(List<Conta> listContas, int indiceConta, double valorSaque)
        {
            listContas[indiceConta].Sacar(valorSaque);
        }

        public void Transferir(List<Conta> listContas, int indiceContaOrigem, int indiceContaDestino, double valorTransferencia)
        {
            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
    }
}
