using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Appatendimento
{
   public class FilaCliente
    {
        private Cliente frente;
        private Cliente tras;

        // Método construtor.
        public FilaCliente()
        {
            // Instância um novo cliente.

            var cli = new Cliente("", "", 0, 0);

            //string cpf = Console.ReadLine(); 
            //string nome = Console.ReadLine();
            //int tempo = 0;
            //int intervalo = 0;

            //var Cliente = new Cliente(cpf, nome, tempo, intervalo);

            frente = cli;
            tras = cli;

            }
        
        // Se a fila está vazia.
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
           
            tras.proximo = cli;
            tras = cli;
        }

        public Cliente Desenfileirar()
        {
           
            Cliente cli = frente.proximo;

            if (!(FilaVazia()))
            {
             
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

    

    public FilaCliente Copiar()
        {
            FilaCliente copiaFila = new FilaCliente();

            Cliente aux = this.frente.proximo;

            while (aux != null)
            {
                aux = aux.proximo;
                copiaFila.Enfileirar(aux);
            }

            return copiaFila;
        }


        public void ImprimirCopia(FilaCliente copiaFila)
        {
            if (copiaFila.FilaVazia())
            {
                Console.WriteLine("A Fila de Clientes do Banco  está vazia! \n\n tecle ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Cliente aux = copiaFila.frente.proximo;
                int i = 1;

                Console.WriteLine("--------------- Cópia da Fila dos clientes no Banco ---------------------\n");
                Console.WriteLine();
                while (aux != null)
                {
                    Console.WriteLine("{0}º O CPF do Cliente da fila: {1}", i, aux.Cpf);
                    Console.WriteLine("{0} O Nome do Cliente da Fila {1}", i, aux.Nome);
                    Console.WriteLine("{0} O Tempo Previsto de atendimento do Cliente da Fila {1}", i, aux.Tempo_de_Atendimento_previsto);
                    Console.WriteLine("{0} O Intervalor de leitura seguirdo do Cliente da Fila {1}", i, aux.Intervalor_de_leitura_seguir);
                    Console.WriteLine("");
                    Console.WriteLine("Opções");
                    Console.WriteLine(" ");
                    aux = aux.proximo;
                    i++;
                }
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("tecle ENTER para continuar...");
                Console.ReadLine();
            }
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
                    Console.WriteLine("{0}º O CPF do Cliente da fila: {1}", i, aux.Cpf);
                    Console.WriteLine("{0} O Nome do Cliente da Fila {1}", i, aux.Nome);
                    Console.WriteLine("{0} O Tempo Previsto de atendimento do Cliente da Fila {1}", i, aux.Tempo_de_Atendimento_previsto);
                    Console.WriteLine("{0} O Intervalor de leitura seguirdo do Cliente da Fila {1}", i, aux.Intervalor_de_leitura_seguir);
                    Console.WriteLine();
                    aux = aux.proximo;
                    i++;
                }

                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine("tecle ENTER para continuar...");
                Console.ReadLine();
            
            
            }

        }

        public FilaCliente Dividir(Cliente cli, Cliente clipar, Cliente climpar)
        {
            FilaCliente filaPar = new FilaCliente();

            if (FilaVazia())
            {
                Console.WriteLine("A Fila de Clientes do Banco  está vazia! \n\n tecle ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Cliente cliente;

                while (!this.FilaVazia())
                {
                    cliente = this.Desenfileirar();

                    filaPar.Enfileirar(cliente);

                }

                int tamanhodafila = 0;

                for (int i = 0; i < tamanhodafila; i++)
                {
                    if (i / 2 == 0)
                    {
                        this.tras.proximo = clipar;
                        this.tras = this.tras.proximo;
                        return null;
                    }
                    else
                    {
                        this.tras.proximo = climpar;
                        this.tras = this.tras.proximo;
                        return null;
                    }

                    return null;
                }
            }
            return null;

        }


        public Boolean VerificarExistencia(String nomeCliente)
        {
            Cliente aux = this.frente;

            while (aux.proximo != null)
            {
                if (aux.proximo.Nome == nomeCliente)
                {
                    return true;
                }
                aux = aux.proximo;
            }
            return false;
        }
    }

  }
