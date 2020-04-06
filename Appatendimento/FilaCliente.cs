using System;
using System.Collections.Generic;
using System.Text;

namespace Appatendimento
{
   public class FilaCliente
    {
        private Cliente frente;
        private Cliente tras;


        public FilaCliente()
        {
            Cliente cli;

           frente = cli;
           tras = cli;

        }

        // Se a fila está vazia
        public Boolean FilaVazia()
        {
           
            if (frente == tras)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Enfileirar(Cliente cli)
        {
            // inserção do novo cliente no final da fila.
            tras.proximo = cli;

            // atualização do atributo de controle tras.
            tras = cli;
        }

        public Cliente Desenfileirar()
        {
            // cli aponta para o cliente da fila que será retornado/desenfileirado, ou seja, 
            //o primeiro cliente da fila.
            Cliente cli = frente.proximo;

            if (!(FilaVazia()))
            {
                // atualização do primeiro cliente da fila.
                frente.proximo = cli.proximo;

                cli.proximo = null;
            }
            return (cli);
        }

        public Cliente ObterPrimeiro()
        {
            if (FilaVazia())
            {
                return null;

            }
            else
            {
                Cliente aux = this.frente.proximo;
                return aux;
            }

        }

        public int ObterNumeroClientes()
        {
            Cliente aux = this.frente.proximo;
            int count = 0;
            while (aux != null)
            {
                aux = aux.proximo;
                count++;
            }

            return count;
        }

        public int ObterNumClientesAFrente(string nomeCliente)
        {
            Cliente aux = this.frente;
            int count = 0;

            while (aux.proximo != null)
            {
                if (aux.proximo.Nome == nomeCliente)
                {
                    Cliente aux_2 = aux.proximo;
                    while (aux_2.proximo != null)
                    {
                        count++;
                    }
                    return count;

                }
                aux = aux.proximo;
            }
            return -1;
        }
        public void Imprimir()
        {
            if (FilaVazia())
            {
                Console.WriteLine("A Fila está vazia! \n\n tecle ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Cliente aux = this.frente.proximo;
                int i = 1;

                Console.WriteLine("--------------- Fila dos Clientes ---------------------\n");
                Console.WriteLine();
                while (aux != null)
                {
                    Console.WriteLine("{0}º O CPF do Cliente da fila: {0}", i, aux.cpf);
                    Console.WriteLine("{1} O Nome do Cliente da Fila {1}", i, aux.nome);
                    Console.WriteLine("{2} O Tempo Previsto de atendimento do Cliente da Fila {2}", i, aux.Tempo_de_Atendimento_previsto);
                    Console.WriteLine("{3} O Intervalor de leitura seguirdo do Cliente da Fila {3}", i,aux.intervalor_de_leitura_seguir);
                    Console.WriteLine();
                    aux = aux.proximo;
                    i++;
                }
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("tecle ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }
}
