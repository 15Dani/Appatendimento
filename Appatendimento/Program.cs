using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Appatendimento
{
    public class Program
    {
        const int MAX_LIMITE_CAIXA_ATENDIMENTO = 5;
        const int MAX_LIMITE_CLIENTE = 25;
        private static List<CaixaAtendimento> CaixaAtendimentoList = new List<CaixaAtendimento>();

        // MENU
        static int Menu()
        {
            int opcao = 0;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" 1 - Enfileirar cliente");
            Console.WriteLine(" 2 - Desenfileirar cliente");
            Console.WriteLine(" 3 - Obter primeiro cliente");
            Console.WriteLine(" 4 - Número total de clientes");
            Console.WriteLine(" 5 - Imprimir");
            Console.WriteLine(" 6 - Dividir");
            Console.WriteLine(" 7 - Verificar se existe cliente");
            Console.WriteLine(" 8 - Obter número de clientes à frente");
            Console.WriteLine(" 9 - Copiar");
            Console.WriteLine("10 - Obter tempo médio de espera");
            Console.WriteLine("11 - Sair");
            Console.WriteLine("12 - Adicionar Cliente no Caixa");
            Console.WriteLine("13 - Listar Clientes de um Caixa Específico");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }
        static void CarregarDados(string nomeArq, FilaCliente filaCliente)
        {
            string[] lines = File.ReadAllLines(nomeArq);

            foreach (string line in lines)
            {

                String[] detalhes = line.Split(";");

                string cpf = detalhes[0];
                string nome = detalhes[1];
                int ta = Int32.Parse(detalhes[2]);
                int il = Int32.Parse(detalhes[3]);

                var cliente = new Cliente(cpf, nome, ta, il);

                //cliente.CaixaAtendimento = ObterClienteCaixa(cpf);
                FabricarCaixaAtendimento();
                filaCliente.Enfileirar(cliente);
            }
        }

        private static CaixaAtendimento ObterClienteCaixa(string cpf)
        {
            var clienteCaixa = new CaixaAtendimento();
            //clienteCaixa.NumeroCaixa = clienteCaixa.GetNumeroCaixaDisponivel();



            return clienteCaixa;

        }

        private static void FabricarCaixaAtendimento()
        {
            if (CaixaAtendimentoList.Count == 0)
            {
                for (int i = 1; i <= MAX_LIMITE_CAIXA_ATENDIMENTO; i++)
                {

                    var list = new List<CaixaAtendimento>();
                    var caixaAtendimento = new CaixaAtendimento
                    {
                        NumeroCaixa = 1
                    };
                    CaixaAtendimentoList.AddRange(new List<CaixaAtendimento>
                {
                    new CaixaAtendimento { NumeroCaixa = i},

                });
                }

            }

        }

        static void Main(string[] args)
        {
            var filaCliente = new FilaCliente();
            var pathRoot = AppDomain.CurrentDomain.BaseDirectory;

            string nomeArq = ($@"{pathRoot}ClienteAtendimento.txt");

            // Check if file already exists. If yes, delete it.     
            if (File.Exists(nomeArq))
            {
                File.Delete(nomeArq);
            }
            // Create a new file     
            using (StreamWriter sw = File.CreateText(nomeArq))
            {
                for (int i = 1; i <= MAX_LIMITE_CLIENTE; i++)
                {
                    var cliente = FabricarCliente(i);
                    sw.WriteLine($"{cliente.Cpf};{cliente.Nome};{cliente.Tempo_de_Atendimento_previsto};{cliente.Intervalor_de_leitura_seguir}");
                }

            }


            CarregarDados(nomeArq, filaCliente);

            filaCliente.Imprimir();



            FilaCliente fila = new FilaCliente();
            int opcao;

            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case 1:
                        Console.Clear();


                        string cpf = Console.ReadLine();
                        string nome = Console.ReadLine();
                        int tempo_de_Atendimento_previsto = 0;
                        int intervalor_de_leitura_seguir = 0;

                        Cliente cliente = new Cliente(cpf, nome, tempo_de_Atendimento_previsto, intervalor_de_leitura_seguir);
                        CarregarDados(nomeArq, filaCliente);

                        filaCliente.Imprimir();

                        break;
                    case 2:
                        Console.Clear();
                        cliente = filaCliente.Desenfileirar();
                        if (cliente != null)
                        {
                            Console.WriteLine("O cliente {0}, saiu da fila do atemdimento!", cliente.Nome);
                            filaCliente.Imprimir();
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("A Fila de Clientes do atemdimento está vazia! \n\n tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        cliente = filaCliente.ObterPrimeiro();
                        if (cliente != null)
                        {
                            Console.WriteLine("O 1º Cliente da fila do atemdimento é: {0}.", cliente.Nome);
                            Console.WriteLine("Tempo de Atendimento previsto {0}.", cliente.Tempo_de_Atendimento_previsto);
                            filaCliente.Imprimir();
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("A Fila de Clientes do atemdimento está vazia! \n\n tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        int count = filaCliente.ObterNumeroClientes();
                        Console.WriteLine("O número total de clientes no atemdimento é de: " + count);
                        filaCliente.Imprimir();
                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();

                        break;
                    case 5:
                        Console.Clear();
                        filaCliente.Imprimir();
                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
 
                        //cliente = filaCliente.Dividir(cli,clipar,cliimpar);
                        //Console.WriteLine("O Cliente da fila a ser dividido é: {0}.", cliente.Nome);
                        filaCliente.Imprimir();
                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Informe o nome do cliente: ");
                        nome = Console.ReadLine();
                        if (filaCliente.VerificarExistencia(nome))
                        {
                            Console.WriteLine("O Cliente pesquisado está na fila do atemdimento !");
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("O Cliente pesquisado não foi encontrado na fila do atemdimento !");
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Informe o nome do cliente: ");
                        string nomeCliente = Console.ReadLine();
                        count = filaCliente.ObterNumClientesAFrente(nomeCliente);
                        if (count != -1)
                        {
                            Console.WriteLine("O número de clientes à frente do " + nomeCliente + " é de: " + count);
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("O Cliente pesquisado não foi encontrado na fila do atemdimento !");
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 9:
                        Console.Clear();
                        FilaCliente copia = filaCliente.Copiar();
                        filaCliente.ImprimirCopia(copia);
                        break;
                    case 10:
                        Console.Clear();

                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("Saindo do sistema! tecle ENTER para finalizar...");
                        Console.ReadLine();
                        break;

                    case 12:
                        Console.Clear();
                        Console.WriteLine("Digite o número do caixa para o próximo cliente");
                        foreach (var caixaAtendimento in CaixaAtendimentoList)
                        {
                            Console.WriteLine($"{caixaAtendimento.NomeDoCaixa}");

                        }
                        int numeroCaixa = Convert.ToInt32(Console.ReadLine());


                        if (numeroCaixa > 0)
                        {
                            var caixaAtendimento = CaixaAtendimentoList.FirstOrDefault(x => x.NumeroCaixa.Equals(numeroCaixa));

                            if (caixaAtendimento.ClienteList.Count == MAX_LIMITE_CAIXA_ATENDIMENTO)
                            {
                                Console.WriteLine($"Caixa já chegou a cota de clientes por fila que é {MAX_LIMITE_CAIXA_ATENDIMENTO}...");
                                Console.WriteLine("tecle ENTER para continuar...");
                                Console.ReadLine();
                                break;
                            }

                            

                                var imprimiCliente = filaCliente.Copiar();
                                var aux = imprimiCliente.frente.proximo;
                                int i = 1;
                                while (aux != null)
                                {
                                    aux = aux.proximo;
                                   
                                    IncluirCaixaAtendimentoDisponivel(ref caixaAtendimento, aux, numeroCaixa);

                                    
                                    i++;
                                }
                            
                        }

                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 13:
                        Console.Clear();
                        Console.WriteLine("Qual número do caixa quer visualizar clientes:");
                       
                        int numeroCaixaVisualizarSelecionado = Convert.ToInt32(Console.ReadLine());


                        if (numeroCaixaVisualizarSelecionado > 0)
                        {
                            var caixaAtendimento = CaixaAtendimentoList.FirstOrDefault(x => x.NumeroCaixa.Equals(numeroCaixaVisualizarSelecionado));

                            if(caixaAtendimento != null)
                            {
                                Console.WriteLine($"##----CAIXA--Nº {caixaAtendimento.NumeroCaixa} --#");
                                if (caixaAtendimento.ClienteList.Count == 0)
                                {
                                   
                                    Console.WriteLine($"Nenhum cliente foi registrado na fila desse caixa");
                                 
                                }
                                foreach (var clienteCaixa in caixaAtendimento.ClienteList)
                                {

                                    Console.WriteLine($"Cleinte Nome: {clienteCaixa.Nome} CPF:{clienteCaixa.Cpf}");
                                }
                            }
                            

                        }

                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida! tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;

                }
            } while (opcao != 11);
        }

        private static void IncluirCaixaAtendimentoDisponivel(ref CaixaAtendimento caixaAtendimento, Cliente aux, int numeroCaixa)
        {
            if (caixaAtendimento != null & caixaAtendimento.ClienteList.Count < MAX_LIMITE_CAIXA_ATENDIMENTO)
            {
                caixaAtendimento.ClienteList.Add(aux);
            }


        }

        private static Cliente FabricarCliente(int numberCliente)
        {
            var tempoAtendimentoPrevisto = GeradorDeTempo(1, 30);
            var tempoIntervaloLeitura = GeradorDeTempo(0, 10);
            return new Cliente(Guid.NewGuid().ToString().Substring(0, 6), $"Cliente - {numberCliente}", tempoAtendimentoPrevisto, tempoIntervaloLeitura);
        }

        private static int GeradorDeTempo(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}



